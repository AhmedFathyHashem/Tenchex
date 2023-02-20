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
	public class PressureGaugesController : Controller
	{
		private readonly TenchexContext _context;

		public PressureGaugesController(TenchexContext context)
		{
			_context = context;
		}



		// GET: PressureGauges
		public async Task<IActionResult> Index()
		{
			return _context.pressureGauges != null ?
						View(await _context.pressureGauges.ToListAsync()) :
						Problem("Entity set 'TenchexContext.pressureGauges'  is null.");
		}

		// GET: PressureGauges/Details/5

		public async Task<IActionResult> Details(Instrumentations ins)
		{
			if (ins == null || _context.pressureGauges == null)
			{
				return NotFound();
			}
			int? id = ins.PressureGaugeId;
			PressureGauge? pressureGauge = await _context.pressureGauges
				.FirstOrDefaultAsync(m => m.PressureGaugeId == id);
			if (pressureGauge == null)
			{
				return NotFound();
			}

			return View(pressureGauge);
		}

		// GET: PressureGauges/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: PressureGauges/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PressureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionMaterial,SpanRange,Accuracy,Repeatabilty,Standard,MountingBracket,MountingBracketMaterial,CaseMaterial,DialSize,CaseFilling,GlassType,OverPressureProtector,BlowOutProtection,Siphone,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] PressureGauge pressureGauge)
		{
			if (ModelState.IsValid)
			{

				_context.Add(pressureGauge);
				await _context.SaveChangesAsync();
				return RedirectToAction("Set", pressureGauge);
			}
			return View(pressureGauge);
		}

		public async Task<IActionResult> Set(PressureGauge pressureGauge)
		{
			Instrumentations instrumentations = new()
			{
				PressureGaugeId = pressureGauge.PressureGaugeId,
				InstrumentType = InstrumentType.PressureGauge
			};
			_context.Add(instrumentations);
			await _context.SaveChangesAsync();
			Types type = new()
			{
				InstrumentId = instrumentations.InstrumentationId
			};
			_context.Add(type);
			await _context.SaveChangesAsync();
			return RedirectToAction("Create" , "Equipments" , type);
		}
		// GET: PressureGauges/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.pressureGauges == null)
			{
				return NotFound();
			}

			var pressureGauge = await _context.pressureGauges.FindAsync(id);
			if (pressureGauge == null)
			{
				return NotFound();
			}
			return View(pressureGauge);
		}

		// POST: PressureGauges/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("PressureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionMaterial,SpanRange,Accuracy,Repeatabilty,Standard,MountingBracket,MountingBracketMaterial,CaseMaterial,DialSize,CaseFilling,GlassType,OverPressureProtector,BlowOutProtection,Siphone,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] PressureGauge pressureGauge)
		{
			if (id != pressureGauge.PressureGaugeId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(pressureGauge);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PressureGaugeExists(pressureGauge.PressureGaugeId))
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
			return View(pressureGauge);
		}

		// GET: PressureGauges/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.pressureGauges == null)
			{
				return NotFound();
			}

			var pressureGauge = await _context.pressureGauges
				.FirstOrDefaultAsync(m => m.PressureGaugeId == id);
			if (pressureGauge == null)
			{
				return NotFound();
			}

			return View(pressureGauge);
		}

		// POST: PressureGauges/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.pressureGauges == null)
			{
				return Problem("Entity set 'TenchexContext.pressureGauges'  is null.");
			}
			var pressureGauge = await _context.pressureGauges.FindAsync(id);
			if (pressureGauge != null)
			{
				_context.pressureGauges.Remove(pressureGauge);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PressureGaugeExists(int id)
		{
			return (_context.pressureGauges?.Any(e => e.PressureGaugeId == id)).GetValueOrDefault();
		}
	}
}
