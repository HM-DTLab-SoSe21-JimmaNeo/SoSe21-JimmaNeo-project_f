﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using SEIIApp.Server.Domain;
using AutoMapper;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class ToDoController : Controller
    {
        private ToDoService ToDoService { get; set; }

        private IMapper Mapper { get; set; }

        public ToDoController(ToDoService todoService, IMapper mapper)
        {
            this.ToDoService = todoService;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ToDoDTO[]> ShowToDos()
        {
            var allUser = ToDoService.GetAllToDo();
            var mappedResult = Mapper.Map<ToDoDTO[]>(allUser);
            return Ok(mappedResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ToDoDTO> AddOrUpdateToDo([FromBody] ToDoDTO ToDoDTO)
        {
            if (ModelState.IsValid)
            {
                var mappedToDo = Mapper.Map<ToDo>(ToDoDTO);

                if (mappedToDo.ToDoID == 0)
                {
                    mappedToDo = ToDoService.AddToDo(mappedToDo);
                    if (mappedToDo == null) return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    mappedToDo = ToDoService.UpdateToDo(mappedToDo);
                }

                var mappedTestDTO = Mapper.Map<ToDoDTO>(mappedToDo);
                return Ok(mappedTestDTO);
            }
            return BadRequest(ModelState);
        }

 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteToDo([FromRoute] int id)
        {
            var todo = ToDoService.GetToDoWithId(id);
            if (todo == null) return StatusCode(StatusCodes.Status404NotFound);
            ToDoService.RemoveToDo(todo);
            return Ok();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ToDoDTO> GetToDoById([FromRoute] int id)
        {
            var todo = ToDoService.GetToDoWithId(id);
            if (todo == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<ToDoDTO>(todo);
            return Ok(mappedResult);
        }

        [HttpGet("author/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ToDoDTO>> GetToDoByAuthorId([FromRoute] int id)
        {
            var todo = ToDoService.GetToDoWithAuthorID(id);
            if (todo == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<List<ToDoDTO>>(todo);
            return Ok(mappedResult);
        }
    }
}