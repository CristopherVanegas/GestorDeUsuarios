﻿using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class PersonaService
    {
        private readonly PersonaRepository _personaRepository;

        public PersonaService(PersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _personaRepository.GetAllAsync();
        }

        public async Task<Persona> GetPersonaAsync(int id)
        {
            return await _personaRepository.GetByIdAsync(id);
        }

        public async Task CreatePersonaAsync(Persona persona)
        {
            // Aquí puedes agregar validaciones de negocio
            await _personaRepository.CreateAsync(persona);
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            await _personaRepository.UpdateAsync(persona);
        }

        public async Task DeletePersonaAsync(int id)
        {
            await _personaRepository.DeleteAsync(id);
        }
    }
}
