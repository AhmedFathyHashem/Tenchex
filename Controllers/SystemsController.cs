using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenchex.Models;

namespace Tenchex.Controllers
{
	public class SystemsController : Controller
	{
		private readonly TenchexContext _context;

		public SystemsController(TenchexContext context)
		{
			_context = context;
		}

		public IActionResult Select(int Id)
		{
			TempData["SelectedSystems"] = Id.ToString();
			return RedirectToAction(nameof(Index));
		}

		// GET: Systems
		public async Task<IActionResult> Index()
		{
			if (TempData.ContainsKey("SelectedSystems"))
			{
#pragma warning disable CS8604 // Possible null reference argument.
				int Id = int.Parse(TempData["SelectedSystems"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
				List<Systems> Sys = (from s in _context.Systems.Include(p => p.Projects)
									 where s.ProjectID == Id
									 select s).ToList();
				TempData["SelectedSystems"] = Id.ToString();
				ViewBag.Name = (from p in _context.Projects
								where p.ProjectId == Id
								select p);
				return View(Sys);

			}
			return _context.Systems != null ?
						View(await _context.Systems.ToListAsync()) :
						Problem("Entity set 'TenchexContext.Systems'  is null.");
		}

		// GET: Systems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Systems == null)
			{
				return NotFound();
			}

			var systems = await _context.Systems
				.FirstOrDefaultAsync(m => m.SystemId == id);
			if (systems == null)
			{
				return NotFound();
			}

			return View(systems);
		}

		// GET: Systems/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Systems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SystemId,SystemName,SystemFluid,ProjectID")] Systems systems)
		{
			if (TempData.ContainsKey("SelectedSystems"))
			{
#pragma warning disable CS8604 // Possible null reference argument.
				systems.ProjectID = int.Parse(TempData["SelectedSystems"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
			}
			if (ModelState.IsValid)
			{
				_context.Add(systems);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(systems);
		}

		// GET: Systems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Systems == null)
			{
				return NotFound();
			}

			var systems = await _context.Systems.FindAsync(id);
			if (systems == null)
			{
				return NotFound();
			}
			return View(systems);
		}

		// POST: Systems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("SystemId,SystemName,SystemFluid,ProjectID")] Systems systems)
		{
			if (id != systems.SystemId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(systems);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!SystemsExists(systems.SystemId))
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
			return View(systems);
		}

		// GET: Systems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Systems == null)
			{
				return NotFound();
			}

			var systems = await _context.Systems
				.FirstOrDefaultAsync(m => m.SystemId == id);
			if (systems == null)
			{
				return NotFound();
			}

			return View(systems);
		}

		// POST: Systems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Systems == null)
			{
				return Problem("Entity set 'TenchexContext.Systems'  is null.");
			}
			var systems = await _context.Systems.FindAsync(id);
			if (systems != null)
			{
				_context.Systems.Remove(systems);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool SystemsExists(int id)
		{
			return (_context.Systems?.Any(e => e.SystemId == id)).GetValueOrDefault();
		}
	}
}
