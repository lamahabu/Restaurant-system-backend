using AutoMapper;
using Contract;
using Domain;
using System;
using EFramework.Data;
using static Domain.Shared.Layer.ErrorsConstant;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class DrinkServices : IDrink
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DrinkServices(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        public DrinkDto Create(CreateDrinkDto dto)
        {
            var drink = _mapper.Map<CreateDrinkDto, Drink>(dto);

            _context.Drinks.Add(drink);
            _context.SaveChanges(); 

            var mapping = _mapper.Map<Drink, DrinkDto>(drink);

            return mapping;
        }

        public void Delete(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);
            if (drink == null)
            {
                throw new Exception(NotFound);
            }

            drink.IsDeleted = true;

            _context.SaveChanges(); 
        }

        public DrinkDto Update(int id, UpdateDrinkDto dto)
        {
            var drink = _mapper.Map<UpdateDrinkDto, Drink>(dto);

            var Founddrink = _context.Drinks.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);

            if (Founddrink == null)
            {
                throw new Exception(NotFound);
            }

            Founddrink.Name = dto.Name;
            Founddrink.Price = dto.Price;

            var mapping = _mapper.Map<Drink, DrinkDto>(Founddrink);

            _context.SaveChanges();

            return mapping;
        }
    }
}
