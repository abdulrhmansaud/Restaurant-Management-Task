    using AutoMapper;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Restaurant_Management_Task.Data;
using Restaurant_Management_Task.Dtos;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Controllers
{

    [Authorize]
    [Route("api/reservation")]
    [ApiController]
    public class ReservationControllers : ControllerBase
    {

        reservationCreateDto ObjCreateDto;
        private readonly reservationRepository _Repository;
        private readonly IMapper _mapper;
        public ReservationControllers(reservationRepository repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }

        //GET api/reservation
        [HttpGet]
        public ActionResult<IEnumerable<reservationReadDto>> GetAllReservation()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reservationList = _Repository.GetAllReservations();
            return Ok(_mapper.Map<IEnumerable<reservationReadDto>>(reservationList).Where(q => q.UserIdforToken == userId));
        }

        //GET api/reservation/{id}
        [HttpGet("{id}", Name = "GetReservationByID")]
        public ActionResult<reservationReadDto> GetReservationByID(int id)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var reservationById = _Repository.GetReservationById(id);

            if (reservationById == null)
            {
                return BadRequest("No record found against this id..");
            }
            return Ok(_mapper.Map<reservationReadDto>(reservationById));

        }

        //Post api/reservation/
        [HttpPost]
        public ActionResult<reservationReadDto> CreateReservation(reservationCreateDto ObjreservationCreateDto)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ObjreservationCreateDto.UserIdforToken = userId;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CreateModel = _mapper.Map<reservation>(ObjreservationCreateDto);
                _Repository.createnewReservation(CreateModel);
                _Repository.SaveChange();

                var ResReadDto = _mapper.Map<reservationReadDto>(CreateModel);

                return CreatedAtRoute(nameof(GetReservationByID), new { Id = ResReadDto.ReservationId }, ResReadDto);
            }
            catch (Exception ex)
            {
                ex.Message.ToLower();
                return StatusCode(400);
            }
        }

        //put api/reservation
        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, reservationUpdateDto reservationUpdateDto)
        {
            var CreateModelUpdate = _Repository.GetReservationById(id);

            if (CreateModelUpdate == null)
            {
                return NotFound();
            }
                _mapper.Map(reservationUpdateDto, CreateModelUpdate);
                _Repository.UpdateReservation(CreateModelUpdate);
                _Repository.SaveChange();
            
            return NoContent();
        }

        // DELETE api/reservation/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {

            var ReservationDeleteModel = _Repository.GetReservationById(id);
            if (ReservationDeleteModel == null)
            {
                return NotFound();
            }

                _Repository.DeleteReservation(ReservationDeleteModel);
                _Repository.SaveChange();
                  return NoContent();
        }
    }
}
