# Calka
Treść zadania:

Napisz we właściwym sobie języku programowania 4 wersje programu, liczącego całkę oznaczoną funkcji:

f(x) = 3*x^3 + cos(7*x) - ln(2*x)

na przedziale [1, 40].

Jako metodę obliczeń przyjmujemy metodę prostokątów, czyli:

- mamy jakieś dx, np. 1e-4 albo 1e-5,

- liczymy sumę f(x) dla x = 1, 1+dx, 1+2dx, ..., c.a. 20

- mnożymy wynik przez dx.

Oczywiście, dzielimy dziedzinę na podprzedziały i każdy wątek sumuje w swoim obszarze.

Proszę napisać i porównać działanie następujących wersyj owego programu:

(i) Wszystkie wątki sumują wynik w tej samej współdzielonej zmiennej - bez synchronizacji (jest to, oczywiście, wersja niepoprawna).

(ii) Wszystkie wątki sumują wynik w tej samej współdzielonej zmiennej - chronionej przez zamek.

(iii) Każdy wątek liczy swoją sumę lokalną, a potem w sekcji krytycznej dodaje ją do globalnej.

(iv) Jakiś inny wariant. Każdy wątek liczy swoją sumę lokalną i np. stosujemy operację redukcji - jeśli mamy taką operację w naszym języku. Co najmniej zaś należy użyć np. zadań zamiast wątków. W języku C# zaleca się użycie TPL, np. Parallel.For() lub Parallel.Invoke().

Uwaga! Proszę dobrać czas działania obliczeń tak, aby program sekwencyjny trwał co najmniej kilka sekund, a lepiej około pół minuty-minutę. Inaczej wyniki przyspieszenia (bądź opóźnienia) będą dość przypadkowe...
