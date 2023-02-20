using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Tenchex.Models;

namespace Tenchex.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly TenchexContext _context;

		public ProjectsController(TenchexContext context)
		{
			_context = context;
		}

		// Send: Projects types
		public async Task<IActionResult> Send()
		{
			//ViewData["ProjectCategory"] = Enum.GetNames(typeof(ProjectCategory));
			return _context.Projects != null ?
						View(await _context.Projects.ToListAsync()) :
						Problem("Entity set 'TenchexContext.Projects'  is null.");
		}
		// Select: Projects types
		public IActionResult Select(ProjectCategory Id)
		{
			TempData["SelectedProjects"] = Id;
			return RedirectToAction(nameof(Index));
		}

		// GET: Projects
		public async Task<IActionResult> Index()
		{
			if (TempData.ContainsKey("SelectedProjects"))
			{
#pragma warning disable CS8605 // Unboxing a possibly null value.
				ProjectCategory Id = (ProjectCategory)TempData["SelectedProjects"];
#pragma warning restore CS8605 // Unboxing a possibly null value.
				List<Projects> Pro = (from P in _context.Projects
									  where Id == P.ProjectCatogry
									  select P).ToList();
				return _context.Projects != null ?
							View(Pro) :
							Problem("Entity set 'TenchexContext.Projects'  is null.");
			}
			return _context.Projects != null ?
						View(await _context.Projects.ToListAsync()) :
						Problem("Entity set 'TenchexContext.Projects'  is null.");
		}

		// GET: Projects/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Projects == null)
			{
				return NotFound();
			}

			var projects = await _context.Projects
				.FirstOrDefaultAsync(m => m.ProjectId == id);
			if (projects == null)
			{
				return NotFound();
			}

			return View(projects);
		}

		// GET: Projects/Create
		public IActionResult Create()
		{
			ViewData["ProjectCategory"] = new SelectList(Enum.GetNames(typeof(ProjectCategory)));
			ViewData["ProjectType"] = new SelectList(Enum.GetNames(typeof(ProjectType)));
			return View();
		}

		// POST: Projects/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectLocation,ProjectOwner,ProjectConsultant,ProjectCatogry,ProjectType")] Projects projects)
		{
			if (ModelState.IsValid)
			{
				_context.Add(projects);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(projects);
		}

		// GET: Projects/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Projects == null)
			{
				return NotFound();
			}
			ViewData["ProjectCategory"] = new SelectList(Enum.GetNames(typeof(ProjectCategory)));
			ViewData["ProjectType"] = new SelectList(Enum.GetNames(typeof(ProjectType)));
			var projects = await _context.Projects.FindAsync(id);
			if (projects == null)
			{
				return NotFound();
			}
			return View(projects);
		}

		// POST: Projects/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectLocation,ProjectOwner,ProjectConsultant,ProjectCatogry,ProjectType")] Projects projects)
		{
			if (id != projects.ProjectId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(projects);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProjectsExists(projects.ProjectId))
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
			return View(projects);
		}

		// GET: Projects/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Projects == null)
			{
				return NotFound();
			}

			var projects = await _context.Projects
				.FirstOrDefaultAsync(m => m.ProjectId == id);
			if (projects == null)
			{
				return NotFound();
			}

			return View(projects);
		}

		// POST: Projects/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Projects == null)
			{
				return Problem("Entity set 'TenchexContext.Projects'  is null.");
			}
			var projects = await _context.Projects.FindAsync(id);
			if (projects != null)
			{
				_context.Projects.Remove(projects);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProjectsExists(int id)
		{
			return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
		}
	}
}
