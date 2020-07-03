using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lan2.Models;

namespace lan2.Controllers
{
    public class InfoPhonesController : ApiController
    {
        private PhoneEntities db = new PhoneEntities();

        // GET: api/InfoPhones
        public IQueryable<InfoPhone> GetInfoPhones()
        {
            return db.InfoPhones;
        }

        // GET: api/InfoPhones/5
        [ResponseType(typeof(InfoPhone))]
        public IHttpActionResult GetInfoPhone(int id)
        {
            InfoPhone infoPhone = db.InfoPhones.Find(id);
            if (infoPhone == null)
            {
                return NotFound();
            }

            return Ok(infoPhone);
        }

        // PUT: api/InfoPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfoPhone(int id, InfoPhone infoPhone)
        {
            if (id != infoPhone.ID)
            {
                return BadRequest();
            }

            db.Entry(infoPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoPhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InfoPhones
        [ResponseType(typeof(InfoPhone))]
        public IHttpActionResult PostInfoPhone(InfoPhone infoPhone)
        {
            db.InfoPhones.Add(infoPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = infoPhone.ID }, infoPhone);
        }

        // DELETE: api/InfoPhones/5
        [ResponseType(typeof(InfoPhone))]
        public IHttpActionResult DeleteInfoPhone(int id)
        {
            InfoPhone infoPhone = db.InfoPhones.Find(id);
            if (infoPhone == null)
            {
                return NotFound();
            }

            db.InfoPhones.Remove(infoPhone);
            db.SaveChanges();

            return Ok(infoPhone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoPhoneExists(int id)
        {
            return db.InfoPhones.Count(e => e.ID == id) > 0;
        }
    }
}