﻿using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("EventDetails")]
    public class EventDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventDetailsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [NonAction]
        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("CaseStudyAPI");
            var token = HttpContext.Session.GetString("jwttoken");
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Trim('"');
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        //GET: List of all events
        [Route("EventList", Name = "EventList")]
        public async Task<IActionResult> GetAllEvents()
        {
            var client = _httpClientFactory.CreateClient("CaseStudyAPI");
            var events = await client.GetFromJsonAsync<List<EventDetails>>("api/v1/Events");
            return View("~/Views/EventDetails/EventList.cshtml", events);
        }

        //  GET: Show add event form
        [HttpGet]
        [Route("AddEvent", Name = "AddEvent")]
        public IActionResult AddEvent()
        {
            return View();
        }

        //POST: Save new event
        [HttpPost]
        [Route("AddEvent")]
        public async Task<IActionResult> AddEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v1/Events", eventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            string errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Error = $"Failed to add event. Status: {response.StatusCode}, Error: {errorContent}";
            return View(eventDetails);
        }

        // GET: Load update form with event data
        [Route("UpdateEvent/{id}", Name = "UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var client = GetClient();
            var eventDetails = await client.GetFromJsonAsync<EventDetails>($"api/v1/Events/{id}");
            return View(eventDetails);
        }

        //POST: Update event
        [HttpPost]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync($"api/v1/Events/{eventDetails.EventId}", eventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            return View(eventDetails);
        }

        // GET: Confirm delete
        [Route("DeleteEvent/{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v1/Events/{id}");
            return View(evt);
        }

        // POST: Perform delete
        [HttpPost]
        [Route("RemoveEvent", Name = "RemoveEvent")]
        public async Task<IActionResult> DeleteEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/v1/Events/{eventDetails.EventId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            return View();
        }

        // GET: Get single event by id
        [Route("GetById/{id}", Name = "GetEventById")]
        public async Task<IActionResult> GetEventsById(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v1/Events/{id}");
            return View(evt);
        }
    }
}
