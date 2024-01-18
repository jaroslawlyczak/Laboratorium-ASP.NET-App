namespace Lab4_App_Reservation.Models
{
    public class LastVisitCookie
    {
        private readonly RequestDelegate _next;
        public static readonly string CookieName = "visit";
        public static readonly string VisitCountCookie = "VISIT_COUNT";
        public LastVisitCookie(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            int visitCount = 1;
            if (context.Request.Cookies.TryGetValue(VisitCountCookie, out string visitCountValue))
            {
                if (int.TryParse(visitCountValue, out int count))
                {
                    visitCount = count + 1;
                }
            }
            context.Response.Cookies.Append(VisitCountCookie, visitCount.ToString(), new CookieOptions { Expires = DateTimeOffset.Now.AddYears(1) });

            string? cookie = context.Request.Cookies[CookieName];
            if (cookie is null) 
            {
                context.Items.Add(CookieName, "First visit");
            }
            else
            {
                if(DateTime.TryParse(cookie, out var date))
                {
                    context.Items[CookieName] = date;
                }
                else
                {
                    context.Items[CookieName] = "Unknown date of last visit";
                }
            }
            CookieOptions options = new CookieOptions() { MaxAge = new TimeSpan(400, 0, 0, 0), IsEssential = true };
            context.Response.Cookies.Append(CookieName, DateTime.Now.ToString(), options);
            await _next(context);
        }
    }
}
