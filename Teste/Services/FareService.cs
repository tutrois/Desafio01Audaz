﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }

        public Boolean TimeValidator(Guid operatorId)
        {
            return GetFares().Any(f =>
            {
                var d = DateTimeOffset.UtcNow - f.DateStamp;
                return f.OperatorId == operatorId && f.Status == 1 && Math.Floor(d.TotalDays / 30) <= 6;
            });

        }
    }
}
