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
    public class DiffrentialPressureGaugesController : Controller
    {
        private readonly TenchexContext _context;

        public DiffrentialPressureGaugesController(TenchexContext context)
        {
            _context = context;
        }

        // GET: DiffrentialPressureGauges
        public async Task<IActionResult> Index()
        {
              return _context.diffrentialPressureGauges != null ? 
                          View(await _context.diffrentialPressureGauges.ToListAsync()) :
                          Problem("Entity set 'TenchexContext.diffrentialPressureGauges'  is null.");
        }

        // GET: DiffrentialPressureGauges/Details/5
        public async Task<IActionResult> Details(Instrumentations ins)
        {
            if (ins == null || _context.diffrentialPressureGauges == null)
            {
                return NotFound();
            }

            DiffrentialPressureGauge? diffrentialPressureGauge = await _context.diffrentialPressureGauges
                .FirstOrDefaultAsync(m => m.DiffrentialPressureGaugeId == ins.DiffrentialPressureGaugeId);
            if (diffrentialPressureGauge == null)
            {
                return NotFound();
            }

            return View(diffrentialPressureGauge);
        }

        // GET: DiffrentialPressureGauges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiffrentialPressureGauges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiffrentialPressureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionMaterial,SpanRange,Accuracy,Repeatabilty,Standard,MountingBracket,MountingBracketMaterial,CaseMaterial,DialSize,CaseFilling,GlassType,OverPressureProtector,BlowOutProtection,Siphone,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] DiffrentialPressureGauge diffrentialPressureGauge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diffrentialPressureGauge);
                await _context.SaveChangesAsync();
                return RedirectToAction("Set", diffrentialPressureGauge);
            }
            return View(diffrentialPressureGauge);
        }

		public async Task<IActionResult> Set(DiffrentialPressureGauge diffrentialPressureGauge)
		{
            Instrumentations instrumentations = new()
            {
                DiffrentialPressureGaugeId = diffrentialPressureGauge.DiffrentialPressureGaugeId,
                InstrumentType = InstrumentType.DPGauge
			};
			_context.Add(instrumentations);
			await _context.SaveChangesAsync();
			Types type = new()
			{
				InstrumentId = instrumentations.InstrumentationId
			};
			_context.Add(type);
			await _context.SaveChangesAsync();
			return RedirectToAction("Create", "Equipments", type);
		}

		// GET: DiffrentialPressureGauges/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.diffrentialPressureGauges == null)
            {
                return NotFound();
            }

            var diffrentialPressureGauge = await _context.diffrentialPressureGauges.FindAsync(id);
            if (diffrentialPressureGauge == null)
            {
                return NotFound();
            }
            return View(diffrentialPressureGauge);
        }

        // POST: DiffrentialPressureGauges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiffrentialPressureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionMaterial,SpanRange,Accuracy,Repeatabilty,Standard,MountingBracket,MountingBracketMaterial,CaseMaterial,DialSize,CaseFilling,GlassType,OverPressureProtector,BlowOutProtection,Siphone,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] DiffrentialPressureGauge diffrentialPressureGauge)
        {
            if (id != diffrentialPressureGauge.DiffrentialPressureGaugeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diffrentialPressureGauge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiffrentialPressureGaugeExists(diffrentialPressureGauge.DiffrentialPressureGaugeId))
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
            return View(diffrentialPressureGauge);
        }

        // GET: DiffrentialPressureGauges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.diffrentialPressureGauges == null)
            {
                return NotFound();
            }

            var diffrentialPressureGauge = await _context.diffrentialPressureGauges
                .FirstOrDefaultAsync(m => m.DiffrentialPressureGaugeId == id);
            if (diffrentialPressureGauge == null)
            {
                return NotFound();
            }

            return View(diffrentialPressureGauge);
        }

        // POST: DiffrentialPressureGauges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.diffrentialPressureGauges == null)
            {
                return Problem("Entity set 'TenchexContext.diffrentialPressureGauges'  is null.");
            }
            var diffrentialPressureGauge = await _context.diffrentialPressureGauges.FindAsync(id);
            if (diffrentialPressureGauge != null)
            {
                _context.diffrentialPressureGauges.Remove(diffrentialPressureGauge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiffrentialPressureGaugeExists(int id)
        {
          return (_context.diffrentialPressureGauges?.Any(e => e.DiffrentialPressureGaugeId == id)).GetValueOrDefault();
        }
    }
}
