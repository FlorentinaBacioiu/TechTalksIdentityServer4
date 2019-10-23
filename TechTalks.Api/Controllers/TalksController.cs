using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechTalks.Api.Models;

namespace TechTalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TalksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Talk> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return new List<Talk> {
                new Talk
                {
                    Title = "Artificial Intelligence, Automation and the Future of Work",
                    Description = "Speaker: Mehdi Kamiri - Head of Digital Center of Excellence Europe. " +
                    "In his role, as Genpact DCOE lead, Mehdi is promoting the development of new growth " +
                    "opportunities, straightening the in house Genpact Digital Culture and encourage " +
                    "collaborative work."
                },
                new Talk
                {
                    Title = "The Future of Self-Driving Cars with WIPRO",
                    Description = "Artificial Intelligent systems are in full swing today, and the promise " +
                    "of ever-increasing applicability opens new possibilities every day. What does the " +
                    "future hold for self-driving cars? Self-driving cars have the potential to drastically " +
                    "reduce road fatalities, ease traffic congestion and let us relax while the car itself " +
                    "does the driving. With big automotive companies investing billions of dollars in the " +
                    "development and implementation of autonomous level 4 systems, the need for experts in " +
                    "this domain has never been greater.At Wipro our aim is the development of intelligent " +
                    "systems that will help our customers build products that will someday achieve the ultimate " +
                    "goal of having Level 5 autonomy.We hope you will join us in this exciting journey that will " +
                    "irrevocably change the way transportation systems work in the future."
                },
                new Talk
                {
                    Title = "Dark Depths of Tomorrow’s Tech: C++ Legacy Code",
                    Description = "Topics: The lifecycle of software systems and where is legacy code " +
                    "coming from; Impact of legacy code on today and tomorrow life(or building a better " +
                    "tomorrow with last decade code); Working on Legacy Systems and attached challenges; " +
                    "Emerging Modern Design when and where there is none;"
                },
                new Talk
                {
                    Title = "Smart Connected Operations – Driving Innovation at Manufacturing Site with Digital " +
                    "Technologies.",
                    Description = "In this presentation we will look at spectrum of use cases that bridge " +
                    "the gap between OT and IT in industrial space. We will see how IIoT, Analytics and AR " +
                    "are changing today’s manufacturing – from enabling real-time visibility into " +
                    "operations, OEE & quality improvements, increased availability of the equipment via " +
                    "predictive maintenance, optimized workforce planning, and many more. Audience will " +
                    "also have a chance to understand typical SCO solution architecture, common deployment " +
                    "models and helpful tips (dos & don’ts) for running project in this space."
                },
                new Talk
                {
                    Title = "How does a GoPro work?",
                    Description = "We’ll discuss about how GoPro evolved from a 35mm film hand strapped camera to 4K, " +
                    "Hypersmooth 2.0 stabilization, TimeWarp 2.0 and machine learning."
                },
                new Talk
                {
                    Title = "Securing modern applications with IdentityServer4",
                    Description = "Security is a major concern in modern applications, either web or mobile, " +
                    "with an increasing number of users. The keynote presents an introduction to IdentityServer4, " +
                    "which is an OAuth 2.0 and OpenID Connect framework for ASP.NET Core. The presentation includes " +
                    "a demo for authentication and access control using Angular on the client side and ASP.NET Core " +
                    "on server side, along with IdentityServer4 framework."
                },
                new Talk
                {
                    Title = "Future of Operations with RPA",
                    Description = "Presentation will cover: Overview on RPA, What are robots, How do they work, " +
                    "How is RPA impacting the operations, New advanced roles coming up due to robotic automation i.e. " +
                    "opportunities & skills. " +
                    "Speaker: Mitra Wani - Mitra has setup and leads the Digital Automation COE at ADP, " +
                    "for more than 3 years.His previous experience is in delivering RPA & Cognitive " +
                    "automation projects in different geographies for banking, insurance, telecom and " +
                    "healthcare verticals.He has worked with most of the RPA products, consulting " +
                    "companies and also have been part of one of the leading RPA Product companies."
                }
            };
        }
    }
}