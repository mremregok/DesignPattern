using OOPEducaiton.UML.CreationalPatterns.BuilderPattern.BankaKredi;

BuilderPatternBankaPersoneli personel = new BuilderPatternBankaPersoneli();

personel.KrediUret(new BireyselKredisiUretimi(), 123, 1000);
personel.KrediUret(new TicaretKredisiUretimi(), 123, 99999);
personel.KrediUret(new AracKredisiUretimi(), 547, 200000);