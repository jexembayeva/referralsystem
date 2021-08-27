using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReferralSystem.General.Services.Controllers
{
    public static class ControllerExtensions
    {
        public static IActionResult List<TItems>(this ControllerBase controller, ICollection<TItems> items)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            return items?.Count > 0 ?
                controller.Ok(items) as IActionResult :
                controller.StatusCode(StatusCodes.Status204NoContent);
        }

        public static IActionResult Get<TItem>(this ControllerBase controller, TItem item)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            return item != null ?
                controller.Ok(item) as IActionResult :
                controller.StatusCode(StatusCodes.Status204NoContent);
        }

        public static IActionResult Check(this ControllerBase controller, bool result)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            return result ?
                controller.Ok() :
                controller.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
