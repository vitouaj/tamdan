using System.Security.Claims;
using ERE.CustomExceptions;
using ERE.DTO;
using ERE.Repository;
using ERE.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace ERE.APIS;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/enroll", [Authorize] async (IStudentRepository service, ClaimsPrincipal user, EnrollmentValidator validator, EnrollmentDto request) => {
            var identifier = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentId = service.GetStudentId(identifier);
            if (string.IsNullOrEmpty(identifier))
                return Results.Unauthorized();
            
            var result = new Response();
            var enrollmentDtos = new List<DTO.EnrollmentDto>();
            try {
                if (request.CourseIds.IsNullOrEmpty())
                    throw new CourseNotFoundException();
                foreach (var courseId in request.CourseIds) {
                    var enrollment = new DTO.EnrollmentDto() {
                        StudentId = studentId,
                        CourseId = courseId
                    };
                    enrollmentDtos.Add(enrollment);
                    // validator.ValidateAndThrow(request);
                }
                result = await service.EnrollCourse(enrollmentDtos);
            } catch (Exception ex) {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result.Success == true ? Results.Ok(result) : Results.BadRequest(result);
        });

        app.MapPatch("/comment", [Authorize] async (IStudentRepository service, ClaimsPrincipal user, ProvideFeedbackDto request) => {
            var identifier = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(identifier)) {
                return Results.Unauthorized();
            }    
            var result = new Response();
            try {
                result = await service.Feedback(request);
            } catch (Exception ex) {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result.Success == true ? Results.Ok(result) : Results.BadRequest(result);
        });

        app.MapGet("/available-course", [Authorize] async (IStudentRepository service, ClaimsPrincipal user) => {
            var identifier = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentId = service.GetStudentId(identifier);
            if (string.IsNullOrEmpty(identifier)) {
                return Results.Unauthorized();
            }    
            var result = new Response();
            try {
                result = await service.GetAvailableCourses(studentId);
            } catch (Exception ex) {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result.Success == true ? Results.Ok(result) : Results.BadRequest(result);
        });

        
    }
    public class EnrollmentDto {
        public List<string> CourseIds { get; set; } = new List<string>();
    }
}
