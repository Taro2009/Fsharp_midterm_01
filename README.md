# Websharper calculator - Midterm No.1

Ez a project a websharperes calculator, az első beadandó a 3 midterm beadandó közül. A Project **Visual Studio**-ban íródott, a template: **Websharper 4 Single Page Application (.NET Core)**

A befejezett project kinézete:

![mid1_ss](mid1_ss.png)



# Fontos file-ok

A legfontosabb két file az **index.html** és a **Client.fs** file, előbbi a html file, utóbbi a code behind F#-ban írva.

# Index.html

## Styling
Az egyik fontos rész a style, ami simán a html kód `<style>` tag-jei között található:

![html_1_ss](html_1_ss.png)

## A számológép elemei
Illetve maga a számológép, amit én egy táblázatként raktam össze, amibe tettem egy **text input**-ot és **button** -okat amik a működésért felelősek:

![html_2_ss](html_2_ss.png)


# Client.fs

Ezt a filet igazából 5 részre bontanám:
- A szám gombokat kezelő kódrészlet
- Az operátorokat kezelő kódrészlet
- Az egyenlóséget és törlést kezelő kódrészlet
- A pattern matching ami a műveletet elvégzi
- Az extra függvények mint a sin, cos és 1/x


Nézzünk ezekre kódrészleteket egyenként!


## Szám gombok

![fs_1_ss](fs_1_ss.png)

## Operátor gombok

![fs_2_ss](fs_2_ss.png)

## Egyenlő, C és AC gombok

![fs_3_ss](fs_3_ss.png)

## Műveletvégző pattern matching

![fs_4_ss](fs_4_ss.png)

## Extra fv-ek, sin, cos, 1/x

![fs_5_ss](fs_5_ss.png)
