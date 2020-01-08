using DentalClinicManagement.Data;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinicManagement.Models.DentalClinicModels.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClinicsController : Controller
    {
        private ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context) {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions) {
            var clinics = _context.Clinics.Select(i => new {
                i.Id,
                i.Name,
                i.Address,
                i.Phone
            });
            return Json(DataSourceLoader.Load(clinics, loadOptions));
        }

        [HttpPost]
        public IActionResult Post(string values) {
            var model = new Clinic();
            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Clinics.Add(model);
            _context.SaveChanges();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public IActionResult Put(int key, string values) {
            var model = _context.Clinics.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Clinic not found");

            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key) {
            var model = _context.Clinics.FirstOrDefault(item => item.Id == key);

            _context.Clinics.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(Clinic model, IDictionary values) {
            string ID = nameof(Clinic.Id);
            string NAME = nameof(Clinic.Name);
            string ADDRESS = nameof(Clinic.Address);
            string PHONE = nameof(Clinic.Phone);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(ADDRESS)) {
                model.Address = Convert.ToString(values[ADDRESS]);
            }

            if(values.Contains(PHONE)) {
                model.Phone = Convert.ToString(values[PHONE]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}