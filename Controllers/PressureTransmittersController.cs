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
    public class PressureTransmittersController : Controller
    {
        private readonly TenchexContext _context;

        public PressureTransmittersController(TenchexContext context)
        {
            _context = context;
        }

        // GET: PressureTransmitters
        public async Task<IActionResult> Index()
        {
              return _context.pressureTransmitters != null ? 
                          View(await _context.pressureTransmitters.ToListAsync()) :
                          Problem("Entity set 'TenchexContext.pressureTransmitters'  is null.");
        }

        // GET: PressureTransmitters/Details/5
        public async Task<IActionResult> Details(Instrumentations ins)
        {
            if (ins == null || _context.pressureTransmitters == null)
            {
                return NotFound();
            }

            PressureTransmitter? pressureTransmitter = await _context.pressureTransmitters
                .FirstOrDefaultAsync(m => m.PressureTransmitterId == ins.PressureTransmitterId);
            if (pressureTransmitter == null)
            {
                return NotFound();
            }

            return View(pressureTransmitter);
        }

        // GET: PressureTransmitters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PressureTransmitters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PressureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionMaterial,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,Installation,MountingBracket,MountingBracketMaterial,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] PressureTransmitter pressureTransmitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pressureTransmitter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Set" , pressureTransmitter);
            }
            return View(pressureTransmitter);
        }


		public async Task<IActionResult> Set(PressureTransmitter pressureTransmitter)
		{
			Instrumentations instrumentations = new()
			{
				PressureTransmitterId = pressureTransmitter.PressureTransmitterId,
                InstrumentType = InstrumentType.PressureTransmitter,
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
		// GET: PressureTransmitters/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pressureTransmitters == null)
            {
                return NotFound();
            }

            var pressureTransmitter = await _context.pressureTransmitters.FindAsync(id);
            if (pressureTransmitter == null)
            {
                return NotFound();
            }
            return View(pressureTransmitter);
        }

        // POST: PressureTransmitters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PressureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionMaterial,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,Installation,MountingBracket,MountingBracketMaterial,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] PressureTransmitter pressureTransmitter)
        {
            if (id != pressureTransmitter.PressureTransmitterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pressureTransmitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PressureTransmitterExists(pressureTransmitter.PressureTransmitterId))
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
            return View(pressureTransmitter);
        }

        // GET: PressureTransmitters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pressureTransmitters == null)
            {
                return NotFound();
            }

            var pressureTransmitter = await _context.pressureTransmitters
                .FirstOrDefaultAsync(m => m.PressureTransmitterId == id);
            if (pressureTransmitter == null)
            {
                return NotFound();
            }

            return View(pressureTransmitter);
        }

        // POST: PressureTransmitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pressureTransmitters == null)
            {
                return Problem("Entity set 'TenchexContext.pressureTransmitters'  is null.");
            }
            var pressureTransmitter = await _context.pressureTransmitters.FindAsync(id);
            if (pressureTransmitter != null)
            {
                _context.pressureTransmitters.Remove(pressureTransmitter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PressureTransmitterExists(int id)
        {
          return (_context.pressureTransmitters?.Any(e => e.PressureTransmitterId == id)).GetValueOrDefault();
        }
    }
}
