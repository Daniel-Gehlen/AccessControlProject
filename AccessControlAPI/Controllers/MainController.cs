using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AccessControlAPI.Models;

namespace AccessControlAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        // Static lists for actual data
        private static List<Person> People = new List<Person>();
        private static List<Service> Services = new List<Service>();
        private static List<Restriction> Restrictions = new List<Restriction>();

        // Predefined Data (People Categories, Area Categories, Services)
        private static List<string> PredefinedPeopleCategories = PredefinedData.PeopleCategories;
        private static List<string> PredefinedAreaCategories = PredefinedData.AreaCategories;
        private static List<string> PredefinedServices = PredefinedData.Services;

        // Endpoint to get predefined people categories
        [HttpGet("predefined/people-categories")]
        public ActionResult<List<string>> GetPredefinedPeopleCategories() => Ok(PredefinedPeopleCategories);

        // Endpoint to get predefined area categories
        [HttpGet("predefined/area-categories")]
        public ActionResult<List<string>> GetPredefinedAreaCategories() => Ok(PredefinedAreaCategories);

        // Endpoint to get predefined services
        [HttpGet("predefined/services")]
        public ActionResult<List<string>> GetPredefinedServices() => Ok(PredefinedServices);

        // Endpoint to get all people
        [HttpGet("people")]
        public ActionResult<List<Person>> GetPeople() => Ok(People);

        // Endpoint to add a new person
        [HttpPost("people")]
        public ActionResult<Person> AddPerson([FromBody] Person person)
        {
            if (person == null) return BadRequest("Person cannot be null.");
            person.Id = People.Count + 1; // Auto-incrementing ID
            People.Add(person);
            return CreatedAtAction(nameof(GetPeople), new { id = person.Id }, person);
        }

        // Endpoint to remove a person
        [HttpDelete("people/{id}")]
        public ActionResult RemovePerson(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound("Person not found.");
            People.Remove(person);
            return Ok(person);
        }

        // Endpoint to get all services
        [HttpGet("services")]
        public ActionResult<List<Service>> GetServices() => Ok(Services);

        // Endpoint to add a new service
        [HttpPost("services")]
        public ActionResult<Service> AddService([FromBody] Service service)
        {
            if (service == null) return BadRequest("Service cannot be null.");
            service.Id = Services.Count + 1; // Auto-incrementing ID
            Services.Add(service);
            return CreatedAtAction(nameof(GetServices), new { id = service.Id }, service);
        }

        // Endpoint to remove a service
        [HttpDelete("services/{id}")]
        public ActionResult<Service> RemoveService(int id)
        {
            var service = Services.FirstOrDefault(s => s.Id == id);
            if (service == null) return NotFound("Service not found.");
            Services.Remove(service);
            return Ok(service);
        }

        // Endpoint to get all restrictions
        [HttpGet("restrictions")]
        public ActionResult<List<Restriction>> GetRestrictions() => Ok(Restrictions);

        // Endpoint to add a new restriction
        [HttpPost("restrictions")]
        public ActionResult<Restriction> AddRestriction([FromBody] Restriction restriction)
        {
            if (restriction == null) return BadRequest("Restriction cannot be null.");
            restriction.Id = Restrictions.Count + 1; // Auto-incrementing ID
            Restrictions.Add(restriction);
            return CreatedAtAction(nameof(GetRestrictions), new { id = restriction.Id }, restriction);
        }

        // Endpoint to remove a restriction
        [HttpDelete("restrictions/{id}")]
        public ActionResult<Restriction> RemoveRestriction(int id)
        {
            var restriction = Restrictions.FirstOrDefault(r => r.Id == id);
            if (restriction == null) return NotFound("Restriction not found.");
            Restrictions.Remove(restriction);
            return Ok(restriction);
        }
    }
}
