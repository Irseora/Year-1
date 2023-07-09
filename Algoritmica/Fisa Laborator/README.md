# Algoritmi Fundamentali - Fisa Laborator

## 1. Algoritmi Fundamentali Numerici & Seminumerici. Sortari
1. Se dau 5 valori întregi a,b,c,d şi e. Construiţi un algoritm care identifică următoarele cazuri:
    - Există 2 valori identice;
    - Există 2 cȃte 2 valori identice;
    - Există 3 valori identice;
    - Există 3 cu 2 valori identice;
    - Există 4 valori identice;
    - Toate valorile sunt identice.

2. Să se verifice dacă valorile date pot fi elementele consecutive ale unei progresii aritmetice cu raţia 1.

3. Alg. de determinare a numerelor prime.

4. Alg. de determinare a cifrelor unui numar.

5. Alg. de determinare a minimului dintr-o multime introdusa secvential si numarul de aparitii ale acestuia.

6. Alg. de determinare a numerelor palindrom.

7. Alg. lui Euclid.

8. Alg. de calcul a sumei / produsului / normei elementelor unui vector.

9. Alg. de calcul a minimului / maximului elementelor unui vector.

10. Alg. de sortare pe baza functiei sign (--, 000, +++). Se da un vector de valori intregi. Sortati astfel incat, valorile de 0 sa ajunga la mijloc, intre valorile negative si cele pozitive.

11. Bubble Sort + Optimizari.

12. Selection Sort.

13. Sortare prin selectie directa.

14. Insertion Sort.

15. Concatenarea a 2 vectori.

16. Reuniunea a 2 vectori.

17. Intersectia a 2 vectori.

18. Diferenta pe multimi a elementelor a 2 vectori.

19. Se dau 2 vectori de dimensiuni diferite. Sa se afiseze daca vectorul mai scurt se regaseste sau nu in vectorul mai lung & numarul de aparitii al sau.

20. Adunarea a 2 numere reprezentate ca vectori de cifre.

21. Produsul a 2 numere reprezentate ca vectori de cifre.

22. Construirea matricii de dimensiune $n \times m$ a primelor $n \times m$ numere prime.

23. Identificarea zonelor dintr-o matrice (de o parte & de alta a diagonalei principale & secundare).
$\begin{pmatrix} 1 && 1 && 0 && 2 && 2 \\ 1 && 1 && 0 && 2 && 2 \\ 0 && 0 && 0 && 0 && 0 \\ 3 && 3 && 0 && 4 && 4 \\ 3 && 3 && 0 && 4 && 4 \end{pmatrix} \ \text{ si } \ \begin{pmatrix} 0 && 1 && 1 && 1 && 0 \\ 4 && 0 && 1 && 0 && 2 \\ 4 && 4 && 0 && 2 && 2 \\ 4 && 0 && 3 && 0 && 2 \\ 0 && 3 && 3 && 3 && 0 \end{pmatrix}$

24. Parcurgerea in sparala a unei matrici.
$\begin{pmatrix} 11 && 12 && 13 && 14 && 15 \\ 16 && 17 && 18 && 19 && 20 \\ 21 && 22 && 23 && 24 && 25 \\ 26 && 27 && 28 && 29 && 30 \\ 31 && 32 && 33 && 34 && 35 \end{pmatrix} \Rightarrow 11, 12, 13, 14, 15, 20, 25, 30, 35, 34, 33, 32, 31, 26, 21, 17, 18, 19, 24, 29, 28, 27, 22, 23$

25. Suma a 2 matrici.

26. Produsul a 2 matrici.

27. Incluziunea a 2 matrici.

---

## 2. Tehnici de programare

### 2.1. Recursivitate
28. Functia factorial recursiv.

29. Generarea sirului Fibonacci recursiv.

30. Fractalul lui Cantor.

31. Fractalul lui Koch (fulg de nea).

32. Fractalul lui Sierpinski.

33. Turnurile din Hanoi cu 3 tije.

34. Turnurile din Hanoi cu 4 tije.

35. Merge Sort.

### 2.2. Revursivitate in Plan
36. Problema platourilor de altitudine maximala intr-o matrice de velori intregi.  
    Se da o matrice de valori intregi. Se defineste un platou ca o secventa de elemente din matrice, adiacente (N, V, S, E), de aceeasi valoare. Pt. o matrice data sa se determine prin afisarea elementelor consecutive, cel mai larg platou.
    $\begin{pmatrix} 1 && 1 && 9 && 4 && 1 \\ 6 && 7 && 8 && 9 && 0 \\ 1 && 2 && 2 && 9 && 5 \\ 1 && 1 && 2 && 9 && 0 \\ 3 && 1 && 3 && 9 && 9 \end{pmatrix} \Rightarrow \{ (1,3), (2,3), (3,3), (4,3), (4,4) \}$

37. Problema teritoriilor (valori 0 adiacente, inconjurate de aceeasi valoare / jocul de Go).  
    Se da o matrice de valori 0, 1, 2. Se defineste teritoriul lui 1, un platou de valoare 0, pt. care toti vecinii sunt 1. Analog, teritoriul lui 2. Pt. o matrice data, contorizati elementele consecutive ale teritoriului lui 1 si 2.

38. Alg. minesweeper.

### 2.3. Metode Aleatoare
39. Metode aleatoare de cautare in spatiul solutiilor: Patratul magic.

40. Metode aleatoare de selectie (Monte Carlo).  
    Se considera ca date de intrare un vector de simboluri & ponderile de aparitie ale acestora. Construiti un algoritm care extrage un simbol din multimea simbolurilor a.i. sa tina cont de ponderea de aparitie a acestuia.

41. Constructia unui jucator virtual in baza selectiei aleatoare pt. jocul Mastermind.

42. Quick Sort.

### 2.4. Divide et Impera
43. Determinarea minimului.

44. Cautare binara.

45. Ridicare la putere a unui numar.

### 2.5. Backtracking
46. Permutarile unei multimi.

47. Aranjamentele unei multimi.

48. Combinarile unei multimi.

49. Submultimile unei multimi.

50. Partitiile unei multimi.

51. Metoda backtracking generalizata.

52. Problema celor N dame.

### 2.6. Greedy
53. Construirea unei sume.  
    Presupunem că trebuie să plătim o sumă de bani S şi că avem la dispoziţie un număr infinit de monede de valoare 25, 10, 5 şi 1. Se cere să se determine numărul minim de monede necesare pentru a plăti suma S.

54. Problema spectacolelor.

55. Implementarea operatorului genetic de mutatie.  
    Fără contextul algoritmilor genetici pentru această problemă se cere construirea unui operator unar ce acţionează pe vectori, astfel încȃt prin acţiunea acestuia se iau la întȃmplare cȃteva elemenet din vectorul iniţial şi acestea se schimbă.

56. Implementarea operatorului genetic de incrucisare.  
    Fără contextul algoritmilor genetici pentru această problemă se cere amestecarea a doi vectori după următorul mecanism: Se aleg cȃteva puncte de tăietură iar vetorul rezultat se obţine prin combinarea celor doi vectori iniţiali copiind alternativ elementele dintre două puncte de tăietură adiacente.
    $(1,2,3,4,5,6,7) + (a, b, c, d, e, f, g) \text{ cu punctele de taietura } (2,5) \Rightarrow (1, 2, c, d, e, 6, 7)$

57. Metoda de selectie bazata pe ordonare.

58. Implementarea unui alg. genetic pt. rezolvarea unui sistem de ecuatii cu ajutorul algoritmilor dezvoltati la 56, 57 & 58.

---

## 3. Domenii Conexe in Algoritmica

### 3.1. Geometrie Computationala
59. Reprezentarea intersectiei a 2 drepte.

60. Construirea recursiva a poligonului dat de mijloacele laturilor poligonului anterior.

61. Alg. lui Jarvis de determinare a invelitorii convexe.

62. Alg. lui Graham de determinare a invelitorii convexe.

### 3.2. Teoria Grafurilor
63. Parcurgerea unui graf.

64. Alg. lui Dijkstra.

65. Alg. lui Bellman Ford.

### 3.3. Tehnici Avansate de Programare. Structuri de Date Inlantuite
66. Lista simplu inlantuita.

67. Lista circulara.

68. Problema cavalerilor mesei rotunde.  
    Se citeşte un număr natural N reprezentând numărul de cavaleri aşezaţi la masa rotundă. Se va începe o numărătoare începând de la cavalerul cu numărul de ordine 1, oprindu-se la cavalerul imediat următor, adică 2, care este eliminat, după aceea, se numără până la 2, oprindu-se pe al doilea cavaler după cel eliminat anterior, acesta fiind cel cu numărul de ordine 4, care este şi el eliminat. După aceea se numără până la 3, oprindu-se pe al treilea cavaler după ultimul eliminat. numărătoarea se opreşte atunci când mai rămâne un singur cavaler neeliminat.

69. Lista dublu inlantuita

### 3.4. Programare Dinamica
70. Alg. lui Lee (labirint).  
    Se dă o matrice pătratică de dimensiune N, cu valori de 0 sau de 1, codificând un labirint. Valoarea 0 reprezintă o cameră deschisă, iar valoarea zero o cameră închisă. Se cere cel mai scurt drum de la poziţia (1, 1) la poziţia (N, N), mergând doar prin camere deschise şi doar la stânga, dreapta, în jos sau în sus. Nu se poate trece de două ori prin acelaşi loc.

71. Problema secventei de suma maxima.  
    Considerăm un număr natural N şi un vector A cu N elemente numere întregi. O subsecvenţă [st, dr] a vectorului A reprezintă secvenţa de elemente $A[st], A[st + 1], ..., A[dr]$. Suma unei subsecvenţe reprezintă suma tuturor elementelor acelei subsecvenţe. Se cere determinarea unei subsecvenţe de sumă maximă.
    $(-6, 1, -3, 4, 5, -1, 3, -8, -9, 1) \Rightarrow 11$

72. Problema rucsacului.  
    Se consideră N obiecte caracterizate de mărimile: greutate şi valoare. Se considerăm un rucscac de capacitate C. Ne interesează alegerea unei submulţimi de obiecte a căror greutate totală să fie cel mult C şi a căror valoare să fie maximă.