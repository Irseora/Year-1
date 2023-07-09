# Curs 3 

- Se da un sir de numere.  
Se cere sa se determine suma celor mai mari 3 valori dintre acestea.  
Lungimea sirului: $n < 10.000$  
Valori: $0 < v_i < 1.000.000$
    - Vector frecventa
    - Bubble Sort
    - Parcurgere liniara

1. Subprogramul cif, cu 2 parametrii, primeste prin intermediul parametrului a un numar natural cu maxim 8 cifre si prin intermediul parametrului b o cifra.  
Subprogramul returneaza numarul de aparitii ale cifrei b in scrierea numarului a.  
Scrieti un program care citeste de la tastatura un numar natural n cu exact 8 cifre si care determina si afiseaza pe ecran cel mai mare numar palindrom ce poate fi obtinut prin rearanjarea tuturor cifrelor numarului n.  
Daca nu se poate crea palindrom, afiseaza 0.

2. Se considera fisierul *BAC.TXT* ce contine un sir crescator cu maxim 1 milion de numere naturale de cel mult 9 cifre fiecare, separate prin cate 1 spatiu.  
Sa se scrie un program care citeste din fisier toti termenii sirului si afiseaza fiecare termen distinct al sirului, urmat de numarul de aparitii ale lui in sir.

3. Evidenta produselor vandute de o societate comerciala este pastrata in fisierul *PRODUSE.TXT*.  
Fisierul are maxim 200.000 de linii si fiecare linie contine 3 numere naturale, ce reprezinta tipul, cantitatea si pretul de vanzare al unui produs.  
Sa se scrie un program care determina pentru fiecare tip de produs vandut suma totala obtinuta in urma vanzarilor.  
Va afisa pe cate o linie tipul produsului si suma totala obtinuta.  
Pentru fiecare vanzare se cunosc:
    - tipul produsului (numar natural de maxim 4 cifre);
    - cantitatea vanduta in kg (numar natural $<= 100$);
    - pretul unui kg (numar natural $<= 100$).  

4. Scrieti un program care citeste o valoare naturala nenula n ($n <= 20$), apoi un sir de n numere naturale, avand fiecare exact 5 cifre.  
Dintre cele n numere citite, programul determina pe acelea care au toate cifrele egale si le afiseaza pe ecran, in ordine crescatoare.

5. In fisierul *BAC.IN* se gasesc numere naturale de cel mult 6 cifre fiecare.  
Se cere sa se determine si afiseze ultimele 2 numere impare (nu neaparat distincte) din fisier.  
Daca nu se gasesc 2, sau nu se gaseste niciunul, se va scrie "Numere insuficiente.".

6. In fisierul numere.txt sunt maxim 10.000 numere naturale cu maxim 9 cifre fiecare.  
Se cere afisarea, in ordine descrescatoare, a tuturor cifrelor care apa in numerele din fisier.

7. Se numeste varf intr-un sir de numere naturale un termen al sirului care este strict mai mare decat fiecare dintre cei 2 vecini ai sai.  
Fisierul *bac.in* contine un sir de maxim $10^6$ numere naturale din intervalul $[0, 10^9]$.  
Se cere sa se afiseze varful sirului, pentru care valoarea absoluta a diferentei dintre cei 2 vecini ai sai este minima.  
Daca exista mai multe astfel de numere, se afiseaza cel mai mare.  
Daca nu exista niciun varf, se afiseaza mesajul "nu exista".

8. Numim pereche asemenea $(x, y)$ 2 numere naturale cu minim 2 cifre, cu proprietatea ca ultimele 2 cifre ale lor sunt egale, eventual in alta ordine.  
Fisierul *numere.in* contine numere naturale din intervalul $[10, 10^5]$.  
Pe prima linie 2 numere nA si nB.  
Pe a doua linie un sir A de nA numere.  
Pe a treia linie un sir B de nB numere.  
Se cere sa se afiseze numarul perechilor asemenea $(x, y)$, cu proprietatea ca $x \in A$, iar $y \in B$.