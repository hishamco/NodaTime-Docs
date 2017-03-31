using Microsoft.AspNetCore.Mvc;

namespace mDocs.Controllers
{
    public class DocumentationController : Controller
    {
        [Route("/{*url}")]
        public IActionResult Index(string url)
        {
            if (url == null || url.EndsWith("/"))
            {
                url += "Index";
            }

            return View(url, GetConfig());
        }

        // TODO: Use the config.json instead
        private static dynamic GetConfig()
        {
            var config = new
            {
                site = new
                {
                    name = "Noda Time",
                    latest = "1.3.2",
                    latest_released_on = "April 14th 2016"
                },
                categories = new[]
                {
                    new
                    {
                        name = "Introduction",
                        pages = new[]
                        {
                            new {  title = "Overview", url = "./" },
                            new {  title = "Why does Noda Time exist?", url = "rationale" },
                            new {  title = "Installation Model", url = "installation" }
                        }
                    },
                    new
                    {
                        name = "Core",
                        pages = new[]
                        {
                            new {  title = "Core concepts", url = "concepts" },
                            new {  title = "Choosing (and converting) between types", url = "type-choices" },
                            new {  title = "Core types quick reference", url = "core-types" },
                            new {  title = "Design philosophy and conventions", url = "design" }
                        }
                    },
                    new
                    {
                        name = "Text",
                        pages = new[]
                        {
                            new {  title = "Text handling", url = "text" },
                            new {  title = "Patterns for Offset values", url = "offest-patterns" },
                            new {  title = "Patterns for LocalTime values", url = "localtime-patterns" },
                            new {  title = "Patterns for LocalDate values", url = "localdate-patterns" },
                            new {  title = "Patterns for LocalDateTime values", url = "localdatetime-patterns" },
                            new {  title = "Patterns for Period values", url = "period-patterns" }
                        }
                    },
                    new
                    {
                        name = "Advanced",
                        pages = new[]
                        {
                            new {  title = "Date and time arithmetic", url = "arithmetic" },
                            new {  title = "BCL conversions", url = "bcl-conversions" },
                            new {  title = "Serialization", url = "serialization" },
                            new {  title = "Threading", url = "threading" }
                        }
                    },
                    new
                    {
                        name = "Library",
                        pages = new[]
                        {
                            new {  title = "Unit testing with Noda Time", url = "testing" },
                            new {  title = "Updating the time zone database", url = "tzdb" },
                            new {  title = "Mono support", url = "mono" },
                            new {  title = "Limitations of Noda Time", url = "limitations" },
                            new {  title = "Version history", url = "versions" }
                        }
                    }
                }
            };

            return config;
        }
    }
}
