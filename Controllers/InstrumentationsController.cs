using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tenchex.Models;

namespace Tenchex.Controllers
{
	public class InstrumentationsController : Controller
	{
		private readonly TenchexContext _context;

		public InstrumentationsController(TenchexContext context)
		{
			_context = context;
		}

		public IActionResult Send()
		{
			return View();
			//return _context.Instrumentations != null ?
			//			View(await _context.Instrumentations.ToListAsync()) :
			//			Problem("Entity set 'TenchexContext.Instrumentations'  is null.");
		}
		public IActionResult Select(InstrumentType Id)
		{
			switch (Id)
			{
				case InstrumentType.PressureGauge:
					return RedirectToAction("Create", "PressureGauges");
				case InstrumentType.PressureTransmitter:
					return RedirectToAction("Create", "PressureTransmitters");
				case InstrumentType.DPGauge:
					return RedirectToAction("Create", "DiffrentialPressureGauges");
				case InstrumentType.DPTransmitter:
					return RedirectToAction("Create", "DiffrentialPressureTransmitters");
				case InstrumentType.TemperatureTransmitter:
					return RedirectToAction("Create", "TemperatureTransmitters");
				case InstrumentType.TemperatureGauge:
					return RedirectToAction("Create", "TemperatureGauges");
				default:
					break;
			}
			return View();
		}

		// GET: Instrumentations
		public async Task<IActionResult> Index()
		{
			var tenchexContext = _context.Instrumentations.Include(i => i.DiffrentialPressureGauge).Include(i => i.DiffrentialPressureTransmitter).Include(i => i.PressureGauge).Include(i => i.PressureTransmitter).Include(i => i.TemperatureGauge).Include(i => i.TemperatureTransmitter);
			return View(await tenchexContext.ToListAsync());
		}

		// GET: Instrumentations/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Instrumentations == null)
			{
				return NotFound();
			}

			var instrumentations = await _context.Instrumentations
				.Include(i => i.DiffrentialPressureGauge)
				.Include(i => i.DiffrentialPressureTransmitter)
				.Include(i => i.PressureGauge)
				.Include(i => i.PressureTransmitter)
				.Include(i => i.TemperatureGauge)
				.Include(i => i.TemperatureTransmitter)
				.FirstOrDefaultAsync(m => m.InstrumentationId == id);
			if (instrumentations == null)
			{
				return NotFound();
			}

			return View(instrumentations);
		}

		// GET: Instrumentations/Create
		public IActionResult Create()
		{
			ViewData["DiffrentialPressureGaugeId"] = new SelectList(_context.diffrentialPressureGauges, "DiffrentialPressureGaugeId", "DiffrentialPressureGaugeId");
			ViewData["DiffrentialPressureTransmitterId"] = new SelectList(_context.diffrentialPressureTransmitters, "DiffrentialPressureTransmitterId", "DiffrentialPressureTransmitterId");
			ViewData["PressureGaugeId"] = new SelectList(_context.pressureGauges, "PressureGaugeId", "PressureGaugeId");
			ViewData["PressureTransmitterId"] = new SelectList(_context.pressureTransmitters, "PressureTransmitterId", "PressureTransmitterId");
			ViewData["TemperatureGaugeId"] = new SelectList(_context.temperatureGauges, "TemperatureGaugeId", "TemperatureGaugeId");
			ViewData["TemperatureTransmitterId"] = new SelectList(_context.temperatureTransmitters, "TemperatureTransmitterId", "TemperatureTransmitterId");
			return View();
		}

		// POST: Instrumentations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("InstrumentationId,InstrumentType,PressureGaugeId,PressureTransmitterId,DiffrentialPressureGaugeId,DiffrentialPressureTransmitterId,TemperatureTransmitterId,TemperatureGaugeId")] Instrumentations instrumentations)
		{
			if (ModelState.IsValid)
			{
				_context.Add(instrumentations);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["DiffrentialPressureGaugeId"] = new SelectList(_context.diffrentialPressureGauges, "DiffrentialPressureGaugeId", "DiffrentialPressureGaugeId", instrumentations.DiffrentialPressureGaugeId);
			ViewData["DiffrentialPressureTransmitterId"] = new SelectList(_context.diffrentialPressureTransmitters, "DiffrentialPressureTransmitterId", "DiffrentialPressureTransmitterId", instrumentations.DiffrentialPressureTransmitterId);
			ViewData["PressureGaugeId"] = new SelectList(_context.pressureGauges, "PressureGaugeId", "PressureGaugeId", instrumentations.PressureGaugeId);
			ViewData["PressureTransmitterId"] = new SelectList(_context.pressureTransmitters, "PressureTransmitterId", "PressureTransmitterId", instrumentations.PressureTransmitterId);
			ViewData["TemperatureGaugeId"] = new SelectList(_context.temperatureGauges, "TemperatureGaugeId", "TemperatureGaugeId", instrumentations.TemperatureGaugeId);
			ViewData["TemperatureTransmitterId"] = new SelectList(_context.temperatureTransmitters, "TemperatureTransmitterId", "TemperatureTransmitterId", instrumentations.TemperatureTransmitterId);
			return View(instrumentations);
		}

		// GET: Instrumentations/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Instrumentations == null)
			{
				return NotFound();
			}

			var instrumentations = await _context.Instrumentations.FindAsync(id);
			if (instrumentations == null)
			{
				return NotFound();
			}
			ViewData["DiffrentialPressureGaugeId"] = new SelectList(_context.diffrentialPressureGauges, "DiffrentialPressureGaugeId", "DiffrentialPressureGaugeId", instrumentations.DiffrentialPressureGaugeId);
			ViewData["DiffrentialPressureTransmitterId"] = new SelectList(_context.diffrentialPressureTransmitters, "DiffrentialPressureTransmitterId", "DiffrentialPressureTransmitterId", instrumentations.DiffrentialPressureTransmitterId);
			ViewData["PressureGaugeId"] = new SelectList(_context.pressureGauges, "PressureGaugeId", "PressureGaugeId", instrumentations.PressureGaugeId);
			ViewData["PressureTransmitterId"] = new SelectList(_context.pressureTransmitters, "PressureTransmitterId", "PressureTransmitterId", instrumentations.PressureTransmitterId);
			ViewData["TemperatureGaugeId"] = new SelectList(_context.temperatureGauges, "TemperatureGaugeId", "TemperatureGaugeId", instrumentations.TemperatureGaugeId);
			ViewData["TemperatureTransmitterId"] = new SelectList(_context.temperatureTransmitters, "TemperatureTransmitterId", "TemperatureTransmitterId", instrumentations.TemperatureTransmitterId);
			return View(instrumentations);
		}

		// POST: Instrumentations/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("InstrumentationId,InstrumentType,PressureGaugeId,PressureTransmitterId,DiffrentialPressureGaugeId,DiffrentialPressureTransmitterId,TemperatureTransmitterId,TemperatureGaugeId")] Instrumentations instrumentations)
		{
			if (id != instrumentations.InstrumentationId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(instrumentations);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!InstrumentationsExists(instrumentations.InstrumentationId))
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
			ViewData["DiffrentialPressureGaugeId"] = new SelectList(_context.diffrentialPressureGauges, "DiffrentialPressureGaugeId", "DiffrentialPressureGaugeId", instrumentations.DiffrentialPressureGaugeId);
			ViewData["DiffrentialPressureTransmitterId"] = new SelectList(_context.diffrentialPressureTransmitters, "DiffrentialPressureTransmitterId", "DiffrentialPressureTransmitterId", instrumentations.DiffrentialPressureTransmitterId);
			ViewData["PressureGaugeId"] = new SelectList(_context.pressureGauges, "PressureGaugeId", "PressureGaugeId", instrumentations.PressureGaugeId);
			ViewData["PressureTransmitterId"] = new SelectList(_context.pressureTransmitters, "PressureTransmitterId", "PressureTransmitterId", instrumentations.PressureTransmitterId);
			ViewData["TemperatureGaugeId"] = new SelectList(_context.temperatureGauges, "TemperatureGaugeId", "TemperatureGaugeId", instrumentations.TemperatureGaugeId);
			ViewData["TemperatureTransmitterId"] = new SelectList(_context.temperatureTransmitters, "TemperatureTransmitterId", "TemperatureTransmitterId", instrumentations.TemperatureTransmitterId);
			return View(instrumentations);
		}

		// GET: Instrumentations/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Instrumentations == null)
			{
				return NotFound();
			}

			var instrumentations = await _context.Instrumentations
				.Include(i => i.DiffrentialPressureGauge)
				.Include(i => i.DiffrentialPressureTransmitter)
				.Include(i => i.PressureGauge)
				.Include(i => i.PressureTransmitter)
				.Include(i => i.TemperatureGauge)
				.Include(i => i.TemperatureTransmitter)
				.FirstOrDefaultAsync(m => m.InstrumentationId == id);
			if (instrumentations == null)
			{
				return NotFound();
			}

			return View(instrumentations);
		}

		// POST: Instrumentations/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Instrumentations == null)
			{
				return Problem("Entity set 'TenchexContext.Instrumentations'  is null.");
			}
			var instrumentations = await _context.Instrumentations.FindAsync(id);
			if (instrumentations != null)
			{
				_context.Instrumentations.Remove(instrumentations);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool InstrumentationsExists(int id)
		{
			return (_context.Instrumentations?.Any(e => e.InstrumentationId == id)).GetValueOrDefault();
		}
	}
}
