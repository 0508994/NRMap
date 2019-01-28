# NRMap
Jednostavna GIS aplikacija za menadžment prirodnih resursa Srbije. Projekat je realizovan u okviru predmeta Geoografski Informacioni Sistemi na Elektronskom fakultetu. 

 Korišćene tehnologije su:
 - SharpMap - biblioteka za geogorafska mapiranja. Izvor: https://github.com/SharpMap 
 - PostGIS ekstenzija za PostgreSQL bazu podataka namenjena za čuvanje i operacije nad geografskim podacima.
 
Aplikacija radi sa tri vektorska sloja: vode, prirodni resursi, i putevi, koji se čuvaju u PostGIS bazi. Pored dodavanja i brisanja slojeva moguća je selekcija entiteta aktivnog sloja klikom miša ili pomoću *Bounding Box* selekcije. Takođe je moguće izvršavati upite na osnovu nekog tematskog atributa aktivnog sloja, izvršavanje prostornih upita između slojeva, kao i rutiranje po mreži puteva pomoću Dijkstrinog algoritma. Slike ekrana za neke od slučajeva korišćenja date su u nastavku.

## Primer korišćenja: Upit nad tematskim atributom sloja
![alt text](https://raw.githubusercontent.com/0508994/NRMap/master/img/nrmap_query_layer.png)

## Primer korišćenja: Prostorni upiti
<p align="center"> 
    <img src="https://raw.githubusercontent.com/0508994/NRMap/master/img/nrmap_sq.png" />
</p>

![alt text](https://raw.githubusercontent.com/0508994/NRMap/master/img/nrmap_sq_result.png)
