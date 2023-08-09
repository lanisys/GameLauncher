using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace GameLauncher
{
    public class Dynamic : IEnumerable
    {
        #region Membres
        private const int LGMAX_INIT = 200;
        private int mLg, mLgmax;
        private int mInternal;
        private Encoding mCodePage; // 1252 par defaut
        private byte[] mPtr = null;
        #endregion
        public int GetLen() { return mLg; }
        public int GetLgmax() { return mLgmax; }
        public byte[] GetPtr() { return mPtr; }
        public void SetLen(int lg)
        {
            if (lg <= mLgmax)
                mLg = lg;
        }
        public void SetCodePage(int num)
        {
            mCodePage = Encoding.GetEncoding(num);
        }
        public Dynamic(int lgmax = LGMAX_INIT)
        {
            // constructeur
            mLg = 0;
            mInternal = -1;
            mCodePage = Encoding.GetEncoding(1252); // Windows
            if (lgmax < LGMAX_INIT)
                mLgmax = LGMAX_INIT;
            else
                mLgmax = lgmax;
            mPtr = new byte[mLgmax];
        }
        public Dynamic(string ch, int lgmax = LGMAX_INIT) : this(lgmax)
        {
            this.Let(ch);
        }
        public override string ToString()
        {
            if (mLg == 0 || mPtr == null)
                return "";
            else
                return mCodePage.GetString(mPtr, 0, mLg);
        }
        public Boolean Ctrl(int lg, Boolean copier)
        {
            if (mPtr == null) return false;
            if (lg > mLgmax)
            {
                mLgmax = ((int)(lg / mLgmax)) * mLgmax + mLgmax;
                Array.Resize<byte>(ref mPtr, mLgmax); // par defaut copie
            }
            if (!copier)
                mLg = 0; // raz si pas de copie
            return mPtr != null;
        }
        public Boolean Let(string ch)
        {
            if (ch.Length > 0)
            {
                if (!Ctrl(ch.Length, false))
                    return false;
                Array.Copy(mCodePage.GetBytes(ch), mPtr, ch.Length);
            }
            mLg = ch.Length;
            return true;
        }
        public Boolean Let(Dynamic dyn)
        {
            if (dyn.GetLen() > 0)
            {
                if (!Ctrl(dyn.GetLen(), false))
                    return false;
                Array.Copy(dyn.GetPtr(), mPtr, dyn.GetLen());
            }
            mLg = dyn.GetLen();
            return true;
        }
        public Boolean Let(Dynamic dyn, int debut, int lg)
        {
            // "debut" en base 0
            if (dyn.GetLen() > 0 && debut < dyn.GetLen() && debut + lg <= dyn.GetLen())
            {
                if (!Ctrl(lg, false))
                    return false;
                Array.Copy(dyn.GetPtr(), debut, mPtr, 0, lg);
                mLg = lg;
            }
            else
                mLg = 0; // pbm d'index : raz de  la chaine
            return true;
        }
        public Boolean Concat(string ch)
        {
            if (ch.Length > 0)
            {
                if (!Ctrl(mLg + ch.Length, true))
                    return false;
                Array.Copy(mCodePage.GetBytes(ch), 0, mPtr, mLg, ch.Length);
                mLg += ch.Length;
            }
            return true;
        }
        public Boolean Concat(Dynamic dyn)
        {
            if (dyn.GetLen() > 0)
            {
                if (!Ctrl(mLg + dyn.GetLen(), true))
                    return false;
                Array.Copy(dyn.GetPtr(), 0, mPtr, mLg, dyn.GetLen());
                mLg += dyn.GetLen();
            }
            return true;
        }
        public Boolean Field(byte separateur, int numChamp, ref Dynamic resultat)
        {
            int iFin, iPos, iScan;
            if (mPtr == null)
                return false;
            resultat.SetLen(0);
            if (mLg < 1)
                return true; // retour vide
            if (numChamp < 1)
                return resultat.Let(this); // retourne la chaîne complète
            // on cherche le bon attribut
            iFin = -1;
            iPos = -1;
            numChamp--;
            // chercher le debut de l'attribut
            for (iScan = iPos + 1; numChamp > 0 && iScan < mLg; iScan++)
                if (mPtr[iScan] == separateur)
                {
                    numChamp--;
                    iPos = iScan;
                }
            if (numChamp != 0)
                return true; // attribut non trouve : fin, retour vide
            // chercher le prochain "car" ou fin de chaine
            for (iScan = iPos + 1; iScan < mLg && iFin == -1; iScan++)
                if (mPtr[iScan] == separateur)
                    iFin = iScan;
            if (iFin == -1)
                iFin = mLg;
            // trouve de iPos+1 a iFin-1
            if (iPos + 1 <= iFin - 1)
                /* resultat non vide : (iFin-iPos-1) cars */
                return resultat.Let(this, iPos + 1, iFin - iPos - 1);
            else  /* vide */
                return true;
        }
        public Boolean Ins(int numChamp, string ch, byte separateur = Const.bFM)
        {
            int iCpt, iPos, iScan, lgChaine, dest, src;
            if (mPtr == null)
                return false;
            if (numChamp < 1)
                return true;
            // on cherche le bon attribut
            lgChaine = ch.Length;
            numChamp--;
            if(mLg == 0)
            {
                // affecter toute la chaine + FM(s) si numChamp > 0
                if (!this.Ctrl(lgChaine + numChamp, false))
                    return false; // erreur alloc memoire
                for (iCpt = 0; iCpt < numChamp; iCpt++)
                    mPtr[iCpt] = separateur;
                mLg = numChamp;
                return this.Concat(ch);
            }
            // chercher le debut de l'attribut
            iPos = -1;
            for (iScan = iPos + 1; numChamp > 0 && iScan < mLg; iScan++)
                if (mPtr[iScan] == separateur)
                {
                    numChamp--;
                    iPos = iScan;
                }
            if (numChamp != 0)
                return true; // attribut non trouve : fin, retour vide
            // chercher le prochain "car" ou fin de chaine
            for (iScan = iPos + 1; iScan < mLg && numChamp > 0; iScan++)
                if (mPtr[iScan] == separateur)
                {
                    iPos = iScan;
                    numChamp--;
                }
            if (numChamp != 0)
            {
                // attribut non trouve : ajouter "numChamp" FM puis la chaine
                if (!this.Ctrl(mLg + lgChaine + numChamp, true))
                    return false; // erreur alloc memoire
                for (iCpt = 0; iCpt < numChamp; iCpt++)
                    mPtr[mLg + iCpt] = separateur;
                mLg += numChamp;
                return this.Concat(ch);
            }

            // insertion a la position trouvee iPos+1 : chaine + separateur (car il reste des cars a la suite... pas a la fin !)
            // => meme si insertion de vide, ajout a minima du separateur
            if (!this.Ctrl(mLg + lgChaine + 1, true))
                return false; // erreur alloc memoire
            // deplacer la fin : deplacer la chaine restant a droite : partir de la fin
            dest = mLg + lgChaine; 
            src = mLg - 1;
            iCpt = mLg - iPos - 1;
            while ((iCpt--) > 0)
            {
                mPtr[dest--] = mPtr[src--];
            }
            mLg += lgChaine + 1;
            /* copier la valeur */
            if (lgChaine > 0)
                Array.Copy(mCodePage.GetBytes(ch), 0, mPtr, iPos + 1, lgChaine);
                //memcpy(mPtr + iPos + 1, chaine, lgChaine);
            // copier a la fin le separateur
            mPtr[iPos + 1 + lgChaine] = separateur;
            return true;
        }
        public Boolean Ins(int numChamp, Dynamic dyn, byte separateur = Const.bFM)
        {
            return this.Ins(numChamp, dyn.ToString(), separateur);
        }
        public Boolean Store(int numChamp, string ch, byte separateur = Const.bFM)
        {
            int iPos, iScan, iFin, iCpt, iLg, lgChaine, src, dest;
            // fonction Dynamic<numChamp> = chaine d'Universe, true si pbm, false si ok
            if (mPtr == null || numChamp < 1)
                return false;
            numChamp--;
            lgChaine = ch.Length; 
            if (mLg == 0)
            {
                // affecter toute la chaine + FM(s) si numChamp > 0
                if (!this.Ctrl(lgChaine + numChamp, false))
                    return false; // erreur alloc memoire
                for (iCpt = 0; iCpt < numChamp; iCpt++)
                    mPtr[iCpt] = separateur;                
                mLg = numChamp;
                return this.Concat(ch);
            }
            // on cherche le bon attribut
            iFin = -1;
            iPos = -1;
            // chercher le debut de l'attribut
            for (iScan = iPos + 1; numChamp > 0 && iScan < mLg; iScan++)
                if (mPtr[iScan] == separateur)
                {
                    numChamp--;
                    iPos = iScan;
                }
            if (numChamp != 0)
            {
                // attribut non trouve : ajouter "numChamp" FM puis la chaine
                if (!this.Ctrl(mLg + lgChaine + numChamp, true))
                    return false; // erreur alloc memoire
                for (iCpt = 0; iCpt < numChamp; iCpt++)
                    mPtr[mLg + iCpt] = separateur;
                mLg += numChamp;
                return this.Concat(ch);
            }
            // chercher le prochain separateur ou fin de chaine
            for (iScan = iPos + 1; iScan < mLg && iFin == -1; iScan++)
                if (mPtr[iScan] == separateur)
                    iFin = iScan;
            if (iFin == -1)
            {
                /* ajout de iPos+1 a la fin... */
                iFin = mLg;
                iLg = lgChaine - (iFin - iPos - 1);
                if (!this.Ctrl(mLg + iLg, true))
                    return (false); // erreur alloc memoire
                mLg += iLg;
                Array.Copy(mCodePage.GetBytes(ch), 0, mPtr, iPos + 1, lgChaine);
                //memcpy(mPtr + iPos + 1, chaine, lgChaine + 1); // +1 pour copier le \0 de fin
                return true;
            }
            // trouve de iPos+1 a iFin-1
            if (lgChaine == 0 && iPos + 1 > iFin - 1)
                return true; /* rien a faire : vide remplace par vide */
            iLg = lgChaine - (iFin - iPos - 1);
            if (!this.Ctrl(mLg + iLg, true))
                return false; // erreur alloc memoire
            mLg += iLg;
            // deplacer la fin
            if (iLg < 0)
                // chaine a mettre plus petite que existant : partir du debut
                Array.Copy(mPtr, iFin, mPtr, iPos + 1 + lgChaine, mLg - iLg - iFin);
                //memcpy(mPtr + iPos + 1 + lgChaine, mPtr + iFin, mLg - iLg - iFin + 1); // copier le \0 de fin egalement *** mLg - iLg - iFin + 1
            else if (iLg > 0)
            {
                /* chaine a mettre plus grande que existant : partir de la fin (memcpy ko ?!) */
                src = mLg - 1 - iLg;
                dest = mLg - 1;
                iCpt = mLg - iFin - iLg;
                while ((iCpt--) > 0)
                    mPtr[dest--] = mPtr[src--];
                //while ((*dest-- = *chaineTmp--) && --iCpt) ; /* s'arrete quand la longueur a été copiée */
            }
            //else
            //    ; // si longueurs identiques : ne rien faire
            // copier la valeur
            if (lgChaine > 0)
                Array.Copy(mCodePage.GetBytes(ch), 0, mPtr, iPos + 1, lgChaine);
                //memcpy(mPtr + iPos + 1, chaine, lgChaine);
            return true;
        }
        public Boolean Store(int numChamp, Dynamic dyn, byte separateur = Const.bFM)
        {
            return this.Store(numChamp, dyn.ToString(), separateur);
        }
        public int Dcount(byte car)
        {
            int nb = 0;
            if (mPtr == null) return -1;
            if (mLg == 0) return nb;
            for (int i = 0; i < mLg; i++)
                if (mPtr[i] == car)
                    nb++;
            return nb + 1;
        }
        public int Locate(string chaine, byte separateur)
        {
            int pos = 1, p = 0, q = 0;
            byte c, d;
            //
            for (; ; pos++)
            {
                q = 0;
                do
                {
                    if (p >= mLg) c = 0; else c = mPtr[p];
                    if (q >= chaine.Length) d = 0; else d = (byte)chaine.ElementAt(q);
                    p++;
                    q++;
                } while (c == d && c != 0 && c != separateur && d != 0);
                //
                if (d == 0 && (c == 0 || c == separateur))
                    return pos; // renvoi no champ
                if (c != separateur && c != 0)
                {
                    do
                    {
                        if (p >= mLg) c = 0; else c = mPtr[p];
                        p++;
                    } while (c != separateur && c != 0);
                }
                if (c == 0)
                    return 0; // pas trouve
            }
        }
        public int Locate(string chaine, bool triCroissant, byte separateur)
        {
            int pos = 1, p = 0, q = 0;
            byte c, d, e;
            /* cas particulier */
            if (mLg == 0)
                return -1;
            //
            for (; ; pos++)
            {
                q = 0;
                do
                {
                    if (p >= mLg) c = 0; else c = mPtr[p];
                    if (q >= chaine.Length) d = 0; else d = (byte)chaine.ElementAt(q);
                    p++;
                    q++;
                } while (c == d && c != 0 && c != separateur && d != 0);
                //
                if (d == 0 && (c == 0 || c == separateur))
                    return pos; // renvoi no champ si egal (trouve) dans les 2 sens croissant/decroissant
                //
                // A FINIR
                if (c == separateur) e = 0; else e = c;
                if ((d < e && triCroissant) || (d > e && !triCroissant))
                    return -pos; // pas trouve : position d'insertion negative
                //
                if (c != separateur && c != 0)
                {
                    do
                    {
                        if (p >= mLg) c = 0; else c = mPtr[p];
                        p++;
                    } while (c != separateur && c != 0);
                }
                if (c == 0)
                    return -(pos + 1); // pas trouve : renvoyer la position de fin+1 en negatif
            }
        }
        public int Remove(ref Dynamic resultat, Boolean raz, byte separateur = Const.bFM)
        {
            int pos1, lg; // mInternal correspond à "pos2"
            // remove "a la universe" ; renvoie l'index du champ lu dans la zone memoire (0 a mLg ; pos1) ; -1 si plus de champ (ou vide)
            // mInternal contient l'index du separateur ou du \0 terminal dans la zone memoire
            // renvoie la position de debut pos1 
            if (raz)
            {
                mInternal = -1;
                return mInternal;
            }
            if (mInternal >= mLg || mInternal < -1)
                return -1; // arrive en bout de chaine (ou mauvaise valeur) : plus de champ
            mInternal++;
            pos1 = mInternal;
            while (mInternal < mLg && mPtr[mInternal] != separateur)
                mInternal++;
            // trouve a pos1 sur une longueur de (mInternal - pos1)
            lg = mInternal - pos1;
            if (resultat.Ctrl(lg, false))
            {
                resultat.SetLen(lg);
                if (lg > 0)
                    Array.Copy(mPtr, pos1, resultat.GetPtr(), 0, lg);
            }
            else
                return -1; // erreur alloc : plus de champ pour l'appelant
            //
            return pos1;
        }
        public Boolean Delete(int numChamp, byte separateur = Const.bFM)
        {
            int iPos, iScan, iFin;
            // fonction "del v<numChamp>" d'Universe 
            if (mPtr == null)
                return false;
            if (numChamp < 1 || mLg == 0)
                return true; // retour sans rien changer
            // on cherche le bon attribut 
            iFin = -1;
            iPos = -1;
            numChamp--;
            // chercher le debut de l'attribut
            for (iScan = iPos + 1; numChamp > 0 && iScan < mLg; iScan++)
                if (mPtr[iScan] == separateur)
                {
                    numChamp--;
                    iPos = iScan;
                }
            //
            if (numChamp != 0)
                return true; // attribut non trouve : ne rien changer
            // chercher le prochain "separateur" ou fin de chaine
            for (iScan = iPos + 1; iScan < mLg && iFin == -1; iScan++)
                if (mPtr[iScan] == separateur)
                    iFin = iScan;
            if (iFin == -1)
            {
                // suppression de iPos+1 a la fin...
                if (iPos + 1 == 0)
                {
                    // vider la chaine
                    mLg = 0;
                    mPtr[0] = 0;
                }
                else
                {
                    // iPos est forcement un separateur ici : suppression aussi
                    mPtr[iPos] = 0;
                    mLg = iPos;
                }
                return true;
            }
            // trouve de iPos+1 a iFin-1 : supprimer de iPos+1 a iFin 
            // deplacer la fin : partir du debut, iFin est forcement un separateur ici
            if(mLg - iFin - 1 > 0)
                Array.Copy(mPtr, iFin + 1, mPtr, iPos + 1, mLg - iFin - 1);
            //memcpy(mPtr + iPos + 1, mPtr + iFin + 1, mLg - iFin); // -1+1 pour copier le \0 de fin
            mLg -= (iFin - iPos);
            return true;
        }
        public int Index(byte car)
        {
            // renvoie la position de la 1ere occurence du caractere, base 1, 0 si non trouvé
            for (int pos = 0; pos < mLg; pos++)
                if (mPtr[pos] == car)
                    return pos + 1;
            return 0;
        }
        public string Substr(int debut, int longueur)
        {
            if (mPtr == null || mLg == 0 || debut < 1 || debut > mLg || longueur < 1)
                return "";
            else
                return mCodePage.GetString(mPtr, debut - 1, longueur);
        }
        public void Convert(byte from, byte to)
        {
            for (int i = 0; i < mLg; i++)
                if (mPtr[i] == from)
                    mPtr[i] = to;
        }
        public Boolean Read(string cheminFichier)
        {
            try
            {
                // ecrit le contenu du Dynamic dans le fichier indiqué, en creation et ecrase un fichier existant
                return this.Let(File.ReadAllText(cheminFichier, mCodePage));
            }
            catch
            {
                return false;
            }
        }
        public Boolean Write(string cheminFichier)
        {
            try
            {
                // ecrit le contenu du Dynamic dans le fichier indiqué, en creation et ecrase un fichier existant
                File.WriteAllText(cheminFichier, this.ToString(), mCodePage);
                return true;
            }
            catch
            {
                return false;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {   
            return (IEnumerator) new DynamicEnumerator(this);
        }
    }
    public class DynamicEnumerator : IEnumerator
    {
        Dynamic dyn;
        int indice = -1;
        public DynamicEnumerator(Dynamic d)
        {
            dyn = d; // pas de copie d'objet : reference
        }
        object IEnumerator.Current
        {
            get
            {
                Dynamic d = new Dynamic();
                dyn.Field(Const.bFM, indice + 1, ref d);
                return d;
            }
        }
        bool IEnumerator.MoveNext()
        {
            indice++;
            return (indice < dyn.Dcount(Const.bFM));
        }
        void IEnumerator.Reset()
        {
            indice = -1;
        }
    }
}

