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
    public class DocotrsController : Controller
    {
        private ApplicationDbContext _context;

        public DocotrsController(ApplicationDbContext context) {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions) {
            var docotrs = _context.Docotrs.Select(i => new {
                i.Id,
                i.Name,
                i.competence,
                i.Phone,
                i.ClinicId
            });
            return Json(DataSourceLoader.Load(docotrs, loadOptions));
        }

        [HttpPost]
        public IActionResult Post(string values) {
            var model = new Docotr();
            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Docotrs.Add(model);
            _context.SaveChanges();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public IActionResult Put(int key, string values) {
            var model = _context.Docotrs.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Docotr not found");

            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key) {
            var model = _context.Docotrs.FirstOrDefault(item => item.Id == key);

            _context.Docotrs.Remove(model);
            _context.SaveChanges();
        }


        [HttpGet]
        public IActionResult ClinicsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Clinics
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(DataSourceLoader.Load(lookup, loadOptions));
        }

        private void PopulateModel(Docotr model, IDictionary values) {
            string ID = nameof(Docotr.Id);
            string NAME = nameof(Docotr.Name);
            string COMPETENCE = nameof(Docotr.competence);
            string PHONE = nameof(Docotr.Phone);
            string CLINIC_ID = nameof(Docotr.ClinicId);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(COMPETENCE)) {
                model.competence = Convert.ToString(values[COMPETENCE]);
            }

            if(values.Contains(PHONE)) {
                model.Phone = Convert.ToString(values[PHONE]);
            }

            if(values.Contains(CLINIC_ID)) {
                model.ClinicId = Convert.ToInt32(values[CLINIC_ID]);
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