# raupjc-hw2
Linq i Async

# Pitanje 1:
Izvođenje je trajalo otprilike 5 sekundi.
# Pitanje 2:
Sve su se izvodile na dretvi 1 (naravno ne istovremeno).

# Pitanje 3:
Otprilike 1 sekundu.
# Pitanje 4:
Izvodile su se na 5 dretvi.

# Pitanje 5:
Ako dvije dretve žele u isto vrijeme pristupiti varijabli dogodit će se sljedeće:
    1. obje će dretve dohvatiti istu vrijednost te varijable,
    2. tu će istu vrijednost povećati za 1,
    3. spremiti će novu vrijednost koja je za 1 manja od očekivanje, jer će svaka u svojo lokalnoj memoriji računati novu vrijednost.
