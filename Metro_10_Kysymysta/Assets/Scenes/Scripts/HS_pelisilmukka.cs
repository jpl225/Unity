using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class HS_pelisilmukka : MonoBehaviour
{
    // Struct -komennolla voi tehdä omia datatyyppejä,
    // joilla on toiminnallisuutta

    public struct Kysymys
    {
        // Määritetään muuttujat
        public string kysymysTeksti;
        // Tässä määritetään joukko muuttujia
        public string[] vastaukset;
        public int oikeaVastaus;

        //muodostetaan konstruktori
        public Kysymys(string erasKysymys, string[] eraatVastaukset, int erasOikeaVastaus)
        {
            this.kysymysTeksti = erasKysymys;
            this.vastaukset = eraatVastaukset;
            this.oikeaVastaus = erasOikeaVastaus;
        }
    }
    // muodostetaan uusi muuttaja(luokka) edellä tehdyllä datatyypillä
    public Kysymys uusiKysymys = new Kysymys("Minkä muotitalon pääsuunnittelija Karl Lagerfeld \n(1933 - 2019) oli 26 vuotta?", new string[] {"Cucci","Chanel","Armani","Prada"},1);

    // muodostetaan painikkeille oma joukko
    public Button[] vastausPainikkeet;
    // Tehdään luokka nimeltä kyselyteksti
    public Text kyselyTeksti;

    // Tehdään joukko, joka sisältää 10 jäsentä Kysymys-tietotyypistä
    private Kysymys[] moniKysely = new Kysymys[30];
    private int nykyinenKysymysIndeksi;
    private int[] valittujenKysymystenMaara = new int[5];
    private int vastatutKysymykset;

    // Tehdään joukko, joka pitää sisällään jo olemassa olevat paneelit,
    // jotta ne voidaan piilottaa
    public GameObject[] KyselyPaneelit;
    // Tehdaan muuttuja, joka pitää sisällään uuden paneelin, että se voidaan
    // tuoda esille
    public GameObject LopullinenTulosTaulu;
    // Tehdään muuttuja varsinaiselle tulokselle (eli siis tekstille)
    public Text tulosTeksti;
    // Tehdään muuttuja, joka laskee oikeiden vastausten määrän
    private int oikeidenVastaustenLkm;
    // Palautteelle muuttuja
    public GameObject palauteTeksti;

    // Start is called before the first frame update
    void Start()
    {
        //print(uusiKysymys.kysymysTeksti + " oikea vastaus:" + uusiKysymys.vastaukset[1]);


        moniKysely[0] = new Kysymys("Minkä muotitalon pääsuunnittelija Karl Lagerfeld \n(1933 - 2019) oli 26 vuotta?", new string[] { "Cucci", "Chanel", "Armani", "Prada" }, 1);
        moniKysely[1] = new Kysymys("Minä vuonna Seefeldissä järjestettiin edellisen kerran hiihdon MM-kisat?", new string[] { "1986", "1987", "1984", "1985" }, 3);
        moniKysely[2] = new Kysymys("Minkä taivaankappaleen kiertoradan pisteitä ovat apogeum ja perigeum?", new string[] { "Marsin", "Jupiterin", "Kuun", "Venuksen" }, 2);
        moniKysely[3] = new Kysymys("Mitä sveitsiläistä lipunmyyntisivustoa kuluttaja-asiamies kehottaa varomaan (kevät 2019)?", new string[] { "Skyscanner", "Myswitzerland", "Viagogo", "Biletto" }, 2);
        moniKysely[4] = new Kysymys("Mikä on Köngäs?", new string[] { "Karhulajike", "Puun loiseläin", "Kanervalajike", "Jyrkästi laskeva koski" }, 3);
        moniKysely[5] = new Kysymys("Kuka suunnitteli pallotuolin (1963)?", new string[] { "Eero Aarnio", "Alvar Aalto", "Kaj Franck", "Pentti Sarpaneva" }, 0);
        moniKysely[6] = new Kysymys("Mikä on Helsingissä 28.2.1943 mitattu helmikuun lämpöennätys Suomessa?", new string[] { "13.2 astetta", "12.8 astetta", "12.2 astetta", "11.8 astetta" }, 3);
        moniKysely[7] = new Kysymys("Kummat kärsivät useammin yliaktiivisesta rakosta, miehet vai naiset?", new string[] { "Miehet", "Naiset", "Eivät kummatkaan", "Molemmat" }, 1);
        moniKysely[8] = new Kysymys("Mistä sanoista tulee ruotsalaispankki SEB:n lyhenne?", new string[] { "Skandinaviska Enskilda Banken", "Sverige Enskilda Banken", "Svensk Enskilda Banken", "Skandinaviska Ekonomi Banken" }, 0);
        moniKysely[9] = new Kysymys("Mikä on Suomen ainoa kotoperäinen nisäkäs?", new string[] { "Suomen pystykorva", "Suomen joutsen", "Saimaan norppa", "Ahven" }, 2);
        moniKysely[10] = new Kysymys("Kuinka monta 20 - 29 vuotiasta suomalaista oli työn ja koulutuksen ulkopuolella vuonna 2018?", new string[] { "n. 93 000", "n. 83 000", "n. 73 000", "n. 103 000" }, 1);
        moniKysely[11] = new Kysymys("Kuka on eduskunnan perustuslakivaliokunnan puheenjohtaja (25.2.2019)?", new string[] { "Annika Lapintie", "Tapani Tölli", "Kimmo Kivelä", "Ville Niinistö" }, 0);
        moniKysely[12] = new Kysymys("Kummat ovat lyhyempiä, vapaan vai perinteisen hiihtotavan sauvat?", new string[] { "Vapaan", "Perinteisen", "Molemmat ovat yhtä pitkät", "Vapaassa ei käytetä sauvoja" }, 1);
        moniKysely[13] = new Kysymys("Kuka suomalainen entinen kilpahiihtäjä on Seefeldissä ensimmäinen nainen maastohiihdon MM-kisojen teknisenä delegaattina (25.2.2019)?", new string[] { "Anne Kyllönen", "Kaisa Mäkäräinen", "Kerttu Niskanen", "Annmari Viljanmaa" }, 3);
        moniKysely[14] = new Kysymys("Kuka on kirjoittanut teoksen Rouva C?", new string[] { "Laila Hirvisaari", "Anna-Leena Härkönen", "Minna Rytisalo", "Rosa Liksom" }, 2);
        moniKysely[15] = new Kysymys("Minkä maakunnan korkein vaara on Koli?", new string[] { "Kainuu", "Pohjois-Karjala", "Etelä-Karjala", "Pohjois-Savo" }, 1);
        moniKysely[16] = new Kysymys("Minkä Suomen vanhan linnan venäläiset räjäyttivät vuonna 1716?", new string[] { "Raaseporin linnan", "Viipurin linnan", "Käkisalmen linnan", "Kajaanin linnan" }, 3);
        moniKysely[17] = new Kysymys("Kuka on Puolan pääministeri (25.2.2019)?", new string[] { "Mateusz Morawiecki", "Jaroslaw Kaczynski", "Andrzej Duda", "Zbigniew Ziobro" }, 0);
        moniKysely[18] = new Kysymys("Minkä ikäinen Matti Nykänen oli kuollessaan?", new string[] { "53", "54", "55", "56" }, 2);
        moniKysely[19] = new Kysymys("Mikä lintu on Pyrrhula pyrrhula?", new string[] { "Sinitiainen", "Vihervarpunen", "Lapinsirkku", "Punatulkku" }, 3);
        moniKysely[20] = new Kysymys("Linux-käyttöjärjestelmä on alkanut levitä myös tavallisten käyttäjien tietokoneille. Mikä ensi kertaa vuonna 2004 käyttöön kannettu jakelupaketti on tehnyt Linuxista varteenotettavan vaihtoehdon myös henkilökohtaisiin koneisiin?", new string[] { "Cymbian", "Red Hat", "OS/2", "Ubuntu" }, 3);
        moniKysely[21] = new Kysymys("Mikä on Monte-Criston kreivin tärkein motiivi toiminnalleen?", new string[] { "Kosto", "Kateus", "Rakkaus", "Uteliaisuus" }, 0);
        moniKysely[22] = new Kysymys("Mikä seuraavista joista on pisin?", new string[] { "Missisippi", "Niili", "Tonava", "Megong" }, 1);
        moniKysely[23] = new Kysymys("Jimi Hendrixin bändin nimi oli...", new string[] { "Cream", "Shadows", "The Jimi Hendrix Band", "The Jimi Hendrix Experience" }, 3);
        moniKysely[24] = new Kysymys("Tämä ohjaaja sai katsojat kannalihalle trillereitä, muun muassa 'Psycholla', kuka hän on?", new string[] { "Wes Craven", "Frank Enstein", "Alfred Hitchcock", "Stephen King" }, 2);
        moniKysely[25] = new Kysymys("Onko lehmällä etuhampaita yläleuassa?", new string[] { "Tietenkin", "Ei", "Lehmällä ei ole ollenkaan hampaita", "Lehmällä on vain ylähampaat" }, 1);
        moniKysely[26] = new Kysymys("Mitä Neuvostoliiton lipun sirppi ja vasara symbolisoi?", new string[] { "Vapautta ja tasa-arvoisuutta", "Työläisiä ja maanviljelijöitä", "Voimaa ja tarkkuutta", "Teollisuutta ja luontoa" }, 1);
        moniKysely[27] = new Kysymys("Mikä näistä tapahtui ensin?", new string[] { "Musta surma", "Kansalaissota", "Mikael Agricola", "Piispa Henrikin surma" }, 3);
        moniKysely[28] = new Kysymys("Mikä seuraavista afrikkalaisista eläimistä lasketaan joukkoon The Big Five?", new string[] { "Puhveli", "Niilinkrokotiili", "Virtahepo", "Kirahvi" }, 0);
        moniKysely[29] = new Kysymys("Ensimmäinen afroamerikkalainen, joka sai Oscarin parhaasta naispääosasta Halle Berry. Mikä oli elokuva, josta hän Oscarin sai?", new string[] { "Monster's Ball", "Gothika", "Catwoman", "Ratkaisun hetket" }, 0);


        maaritaKysymys();
        liitaVastaukset(valittujenKysymystenMaara[0]);
    }

    // Update is called once per frame
    void Update()
    {
        lopetaPeli();
    }

    void liitaVastaukset(int kysymysnum)
    {
        uusiKysymys = moniKysely[kysymysnum];
        kyselyTeksti.text = uusiKysymys.kysymysTeksti;
        for (int i = 0; i < vastausPainikkeet.Length; i++)
        {
            vastausPainikkeet[i].GetComponentInChildren<Text>().text = uusiKysymys.vastaukset[i];
        }
    }

    public void tarkistaVastaus(int painikeNum)
    {
        if(painikeNum == uusiKysymys.oikeaVastaus)
        {
            //ColorBlock theColor = vastausPainikkeet[painikeNum].GetComponent<Button>().colors;
            //theColor.normalColor = Color.green;
            //vastausPainikkeet[painikeNum].GetComponent<Button>().colors = theColor;
            print("Aivan oikein!");
            oikeidenVastaustenLkm++;
            palauteTeksti.GetComponent<Text>().text = "Oikein";
            palauteTeksti.GetComponent<Text>().color = Color.green;

        }
        else
        {
            //ColorBlock theColor = vastausPainikkeet[painikeNum].GetComponent<Button>().colors;
            //theColor.normalColor = Color.red;
            //vastausPainikkeet[painikeNum].GetComponent<Button>().colors = theColor;
            print("Yritäpä uudelleen:");
            palauteTeksti.GetComponent<Text>().text = "Väärin";
            palauteTeksti.GetComponent<Text>().color = Color.red;

        }

        if (vastatutKysymykset < valittujenKysymystenMaara.Length - 1)
        {
            palauteTeksti.SetActive(false);
            Thread.Sleep(1000);
            palauteTeksti.SetActive(true);
            siirrySeuraavaanKysymykseen();
            vastatutKysymykset++;
        }
        else
        {
            foreach (GameObject p in KyselyPaneelit)
            {
                p.SetActive(false);
            }
            LopullinenTulosTaulu.SetActive(true);
            naytaVastaukset();
        }
    }

    void maaritaKysymys()
    {
        // Valitaan haluttu määrä kysymyksiä randomisti kysymysten joukosta
        for (int i=0; i < valittujenKysymystenMaara.Length; i++ )
        {
            nykyinenKysymysIndeksi = Random.Range(0, moniKysely.Length);
            // Käynnistetään apuohjelma, joka tarkastaa, onko kysymys jo joukossa,
            // jos ei, se lisätään mukaan
            if(NumeroEiMukana(valittujenKysymystenMaara, nykyinenKysymysIndeksi))
            {
                valittujenKysymystenMaara[i] = nykyinenKysymysIndeksi;
            }
            // jos on, lisätään looppiin yksi kierros, jotta pystytään arpomaan
            // uusi kysymys
            else
            {
                i--;
            }
           
        }
        nykyinenKysymysIndeksi = Random.Range(0, moniKysely.Length);
    }

    // Tämä apuohjelma siis käy läpi kysymykset ja tarkistaa, onko valittu kysymys
    // jo olemassa olevien joukossa
    bool NumeroEiMukana(int[] numerot, int num)
    {
        for(int j = 0; j < numerot.Length; j++)
        {
            if(num == numerot[j])
            {
                return false;
            }
        }
        return true;
    }

    public void siirrySeuraavaanKysymykseen()
    {
        liitaVastaukset(valittujenKysymystenMaara[valittujenKysymystenMaara.Length - 1 - vastatutKysymykset]);
    }

    public void naytaVastaukset()
    {
        switch (oikeidenVastaustenLkm)
        {
            case 5:
                tulosTeksti.text = "5 vastausta 5:stä oikein! \nOlet kaikkitietävä!";
                break;
            case 4:
                tulosTeksti.text = "4 vastausta 5:stä oikein! \nOlet todella viisas!";
                break;
            case 3:
                tulosTeksti.text = "3 vastausta 5:stä oikein! \nHyvin tiedetty!";
                break;
            case 2:
                tulosTeksti.text = "2 vastausta 5:stä oikein! \nParempi onni ensi kerralla!";
                break;
            case 1:
                tulosTeksti.text = "1 vastausta 5:stä oikein! \nPystyt parempaankin!";
                break;
            case 0:
                tulosTeksti.text = "0 vastausta 5:stä oikein! \nYrititkö edes?";
                break;
            default:
                print("Tätä tekstiä ei pitäisi tulla!");
                break;
        }
    }

    public void aloitaTasoUudelleen()
    {
        Application.LoadLevel (Application.loadedLevelName);
    }

    void lopetaPeli()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
