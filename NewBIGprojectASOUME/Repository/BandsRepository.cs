using NewBIGprojectASOUME.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace NewBIGprojectASOUME.Repository
{
    public class BandsRepository: IDisposable
    {
        private readonly ApplicationDbContext _Context;

        public BandsRepository()
        {
            _Context = new ApplicationDbContext();
        }

        public IEnumerable<Band> GetAll()
        {
            return _Context
                .Bands
                .Include(b => b.Artists)
                .Include(a => a.User);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
        
        public Band GetAllById(int? id)
        {
            if(id == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var Band = _Context.Bands
                .Include(b => b.Artists)
                .Include(a => a.User)
                .SingleOrDefault(c => c.Id == id);

            if (Band == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Band;
        }

        public void Create(Band band)
        {
            _Context.Bands.Add(band);
            Save();
        }

        public  void Update(Band band)
        {
            _Context.Entry(band).State = EntityState.Modified;
            Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var band = _Context.Bands.SingleOrDefault(b => b.Id == id);
            _Context.Bands.Remove(band);
            Save();

        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}