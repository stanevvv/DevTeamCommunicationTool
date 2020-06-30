using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevTeamCommunicationTool.Areas.Identity.Data;
using DevTeamCommunicationTool.Areas.Identity;
using Microsoft.AspNetCore.Identity;

namespace DevTeamCommunicationTool.Controllers
{
    public class MessagesController : Controller
    {
        private readonly CommunicationToolDbContext _context;
        private readonly UserManager<User> _userManager;

        public MessagesController(CommunicationToolDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return View(await _context.Messages.Include(m => m.SentBy).Where(m => m.SentTo.Email == currentUser.Email).ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,SendDate,RecieverEmail,SentBy,SentTo")] Message message)
        {
            if (ModelState.IsValid && _userManager.Users.Any(u => u.Email == message.RecieverEmail))
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var reciever = await _userManager.FindByEmailAsync(message.RecieverEmail);

                message.SentBy = currentUser;
                message.SentTo = reciever;

                currentUser.MessagesSent.Add(message);
                reciever.MessagesRecieved.Add(message);


                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                ViewBag.Message = message;
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,SendDate")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
