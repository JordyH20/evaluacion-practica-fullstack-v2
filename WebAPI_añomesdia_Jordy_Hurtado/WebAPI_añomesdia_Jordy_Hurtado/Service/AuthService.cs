using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI_añomesdia_Jordy_Hurtado.Data;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Response;
using WebAPI_añomesdia_Jordy_Hurtado.Models;

namespace WebAPI_añomesdia_Jordy_Hurtado.Service
{
    public class AuthService
    {
        private readonly DbConexion _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;

        public AuthService(DbConexion context, IPasswordHasher<User> passwordHasher, JwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var correo = request.Correo.Trim().ToLowerInvariant();

            var usuario = await _context.Users.SingleOrDefaultAsync(u => u.Correo == correo);

            if (usuario == null)
                return null;

            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, request.Password);

            if (resultado == PasswordVerificationResult.Failed)
                return null;

            // Actualiza el hash si el hasher recomienda renovarlo.
            if (resultado == PasswordVerificationResult.SuccessRehashNeeded)
            {
                usuario.PasswordHash = _passwordHasher.HashPassword(
                    usuario,
                    request.Password);

                await _context.SaveChangesAsync();
            }

            var (token, expiracion) = _jwtService.GenerarToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                ExpiraEn = expiracion,
                UsuarioId = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol.ToString()
            };
        }





        public async Task<UsuarioResponseDto?> RegistrarAsync(RegistroUsuarioRequestDto request)
        {
            var correo = request.Correo.Trim().ToLowerInvariant();

            var existe = await _context.Users
                .AnyAsync(u => u.Correo.ToLower() == correo);

            if (existe)
                return null;

            var usuario = new User
            {
                Nombre = request.Nombre.Trim(),
                Correo = correo,
                Rol = request.Rol
            };

            usuario.PasswordHash = _passwordHasher.HashPassword(
                usuario,
                request.Password
            );

            _context.Users.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol.ToString()
            };
        }



        public async Task<IEnumerable<UsuarioResponseDto>> ObtenerUsuariosAsync()
        {
            var usuarios = await _context.Users.ToListAsync();
            return usuarios.Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Rol = u.Rol.ToString()
            });
        }
    }
}
