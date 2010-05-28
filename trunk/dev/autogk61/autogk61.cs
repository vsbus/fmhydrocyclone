/*************************************************************************
Copyright (c) 2005-2007, Sergey Bochkanov (ALGLIB project).

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer.

- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.

- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*************************************************************************/

using System;

class autogk61
{
    /*
    This members must be defined by you:
    static double f(double x)
    */


    /*************************************************************************
    Интегрирование с заданной точностью на основе квадратурной формулы Гаусса-
    Кронрода с 61 точкой.

    Функция F(x) - интегрируемая функция

    Входные параметры:
        A,B         -   задают отрезок интегрирования [A,B]
        Eps         -   желаемая АБСОЛЮТНАЯ точность интегрирования
        HeapSize    -   макисмальное число суботрезков, на которые может быть
                        разбит отрезок (при этом  в  подпрограмме  выделяется
                        выделяется  массив  размером  4*HeapSize  чисел   под
                        таблицу интегралов на этих отрезках).
                        
    Выходные параметры:
        Integral    -   вычисленное значение интеграла.
        HeapUsed    -   число использованных отрезков разбиения.

    Результат:
        True        -   если интеграл был успешно найден с требуемой абсолютной
                        точностью.
        False       -   если указанного числа отрезков  разбиения  не  хватило
                        для нахождения интеграла с требуемой точностью.
                        
    Независимо от того, был интеграл найден с требуемой  точностью,  или  нет,
    в Integral и HeapSize возвращаются  значения  интеграла  и числа  отрезков
    разбиения.

      -- ALGLIB --
         Copyright 2005 by Bochkanov Sergey
    *************************************************************************/
    public static bool autogk61integrator(double a,
        double b,
        double eps,
        int heapsize,
        ref double integral,
        ref int heapused)
    {
        bool result = new bool();
        double[,] heap = new double[0,0];
        int heapw = 0;
        double sumerr = 0;
        double[] x = new double[0];
        double[] wg = new double[0];
        double[] wk = new double[0];
        int n = 0;
        int ng = 0;
        int i = 0;
        int j = 0;
        int h = 0;
        double v = 0;
        double c1 = 0;
        double c2 = 0;
        double intg = 0;
        double intk = 0;
        double ta = 0;
        double tb = 0;

        heapw = 4;
        heap = new double[heapsize-1+1, heapw-1+1];
        n = 61;
        ng = 15;
        x = new double[n-1+1];
        wk = new double[n-1+1];
        wg = new double[n-1+1];
        for(i=0; i<=n-1; i++)
        {
            x[i] = 0;
            wk[i] = 0;
            wg[i] = 0;
        }
        wg[0] = 0.007968192496166605615465883474674;
        wg[1] = 0.018466468311090959142302131912047;
        wg[2] = 0.028784707883323369349719179611292;
        wg[3] = 0.038799192569627049596801936446348;
        wg[4] = 0.048402672830594052902938140422808;
        wg[5] = 0.057493156217619066481721689402056;
        wg[6] = 0.065974229882180495128128515115962;
        wg[7] = 0.073755974737705206268243850022191;
        wg[8] = 0.080755895229420215354694938460530;
        wg[9] = 0.086899787201082979802387530715126;
        wg[10] = 0.092122522237786128717632707087619;
        wg[11] = 0.096368737174644259639468626351810;
        wg[12] = 0.099593420586795267062780282103569;
        wg[13] = 0.101762389748405504596428952168554;
        wg[14] = 0.102852652893558840341285636705415;
        x[0] = 0.999484410050490637571325895705811;
        x[1] = 0.996893484074649540271630050918695;
        x[2] = 0.991630996870404594858628366109486;
        x[3] = 0.983668123279747209970032581605663;
        x[4] = 0.973116322501126268374693868423707;
        x[5] = 0.960021864968307512216871025581798;
        x[6] = 0.944374444748559979415831324037439;
        x[7] = 0.926200047429274325879324277080474;
        x[8] = 0.905573307699907798546522558925958;
        x[9] = 0.882560535792052681543116462530226;
        x[10] = 0.857205233546061098958658510658944;
        x[11] = 0.829565762382768397442898119732502;
        x[12] = 0.799727835821839083013668942322683;
        x[13] = 0.767777432104826194917977340974503;
        x[14] = 0.733790062453226804726171131369528;
        x[15] = 0.697850494793315796932292388026640;
        x[16] = 0.660061064126626961370053668149271;
        x[17] = 0.620526182989242861140477556431189;
        x[18] = 0.579345235826361691756024932172540;
        x[19] = 0.536624148142019899264169793311073;
        x[20] = 0.492480467861778574993693061207709;
        x[21] = 0.447033769538089176780609900322854;
        x[22] = 0.400401254830394392535476211542661;
        x[23] = 0.352704725530878113471037207089374;
        x[24] = 0.304073202273625077372677107199257;
        x[25] = 0.254636926167889846439805129817805;
        x[26] = 0.204525116682309891438957671002025;
        x[27] = 0.153869913608583546963794672743256;
        x[28] = 0.102806937966737030147096751318001;
        x[29] = 0.051471842555317695833025213166723;
        x[30] = 0.000000000000000000000000000000000;
        wk[0] = 0.001389013698677007624551591226760;
        wk[1] = 0.003890461127099884051267201844516;
        wk[2] = 0.006630703915931292173319826369750;
        wk[3] = 0.009273279659517763428441146892024;
        wk[4] = 0.011823015253496341742232898853251;
        wk[5] = 0.014369729507045804812451432443580;
        wk[6] = 0.016920889189053272627572289420322;
        wk[7] = 0.019414141193942381173408951050128;
        wk[8] = 0.021828035821609192297167485738339;
        wk[9] = 0.024191162078080601365686370725232;
        wk[10] = 0.026509954882333101610601709335075;
        wk[11] = 0.028754048765041292843978785354334;
        wk[12] = 0.030907257562387762472884252943092;
        wk[13] = 0.032981447057483726031814191016854;
        wk[14] = 0.034979338028060024137499670731468;
        wk[15] = 0.036882364651821229223911065617136;
        wk[16] = 0.038678945624727592950348651532281;
        wk[17] = 0.040374538951535959111995279752468;
        wk[18] = 0.041969810215164246147147541285970;
        wk[19] = 0.043452539701356069316831728117073;
        wk[20] = 0.044814800133162663192355551616723;
        wk[21] = 0.046059238271006988116271735559374;
        wk[22] = 0.047185546569299153945261478181099;
        wk[23] = 0.048185861757087129140779492298305;
        wk[24] = 0.049055434555029778887528165367238;
        wk[25] = 0.049795683427074206357811569379942;
        wk[26] = 0.050405921402782346840893085653585;
        wk[27] = 0.050881795898749606492297473049805;
        wk[28] = 0.051221547849258772170656282604944;
        wk[29] = 0.051426128537459025933862879215781;
        wk[30] = 0.051494729429451567558340433647099;
        for(i=n-1; i>=n/2; i--)
        {
            x[i] = -x[n-1-i];
        }
        for(i=n-1; i>=n/2; i--)
        {
            wk[i] = wk[n-1-i];
        }
        for(i=ng-1; i>=0; i--)
        {
            wg[n-2-2*i] = wg[i];
            wg[1+2*i] = wg[i];
        }
        for(i=0; i<=n/2; i++)
        {
            wg[2*i] = 0;
        }
        c1 = 0.5*(b-a);
        c2 = 0.5*(b+a);
        intg = 0;
        intk = 0;
        for(i=0; i<=n-1; i++)
        {
            v = f(c1*x[i]+c2);
            intk = intk+v*wk[i];
            if( i%2==1 )
            {
                intg = intg+v*wg[i];
            }
        }
        intk = intk*(b-a)*0.5;
        intg = intg*(b-a)*0.5;
        heap[0,0] = Math.Abs(intg-intk);
        heap[0,1] = intk;
        heap[0,2] = a;
        heap[0,3] = b;
        sumerr = heap[0,0];
        if( sumerr<eps )
        {
            result = true;
            integral = intk;
            heapused = 1;
            return result;
        }
        heapused = 1;
        for(h=1; h<=heapsize-1; h++)
        {
            heapused = h+1;
            mheappop(ref heap, h, heapw);
            sumerr = sumerr-heap[h-1,0];
            ta = heap[h-1,2];
            tb = heap[h-1,3];
            heap[h-1,2] = ta;
            heap[h-1,3] = 0.5*(ta+tb);
            heap[h,2] = 0.5*(ta+tb);
            heap[h,3] = tb;
            for(j=h-1; j<=h; j++)
            {
                c1 = 0.5*(heap[j,3]-heap[j,2]);
                c2 = 0.5*(heap[j,3]+heap[j,2]);
                intg = 0;
                intk = 0;
                for(i=0; i<=n-1; i++)
                {
                    v = f(c1*x[i]+c2);
                    intk = intk+v*wk[i];
                    if( i%2==1 )
                    {
                        intg = intg+v*wg[i];
                    }
                }
                intk = intk*(heap[j,3]-heap[j,2])*0.5;
                intg = intg*(heap[j,3]-heap[j,2])*0.5;
                heap[j,0] = Math.Abs(intg-intk);
                heap[j,1] = intk;
                sumerr = sumerr+heap[j,0];
            }
            mheappush(ref heap, h-1, heapw);
            mheappush(ref heap, h, heapw);
            if( sumerr<eps )
            {
                break;
            }
        }
        result = sumerr<eps;
        integral = 0;
        for(j=0; j<=heapused-1; j++)
        {
            integral = integral+heap[j,1];
        }
        return result;
    }


    /*************************************************************************
    Служебная подпрограмма - удаление из кучи самого большого элемента

    Алгоритм  перемещает  элемент  за  пределы  кучи  (в  элемент  с   номером
    HeapSize-1), затем вновь упорядочивает кучу.
    *************************************************************************/
    private static void mheappop(ref double[,] heap,
        int heapsize,
        int heapwidth)
    {
        int i = 0;
        int p = 0;
        double t = 0;
        int maxcp = 0;

        if( heapsize==1 )
        {
            return;
        }
        for(i=0; i<=heapwidth-1; i++)
        {
            t = heap[heapsize-1,i];
            heap[heapsize-1,i] = heap[0,i];
            heap[0,i] = t;
        }
        p = 0;
        while( 2*p+1<heapsize-1 )
        {
            maxcp = 2*p+1;
            if( 2*p+2<heapsize-1 )
            {
                if( heap[2*p+2,0]>heap[2*p+1,0] )
                {
                    maxcp = 2*p+2;
                }
            }
            if( heap[p,0]<heap[maxcp,0] )
            {
                for(i=0; i<=heapwidth-1; i++)
                {
                    t = heap[p,i];
                    heap[p,i] = heap[maxcp,i];
                    heap[maxcp,i] = t;
                }
                p = maxcp;
            }
            else
            {
                break;
            }
        }
    }


    /*************************************************************************
    Служебная подпрограмма - добавление элемента в кучу

    Алгоритм   добавляет элемент с номером HeapSize, затем вновь упорядочивает
    кучу.
    *************************************************************************/
    private static void mheappush(ref double[,] heap,
        int heapsize,
        int heapwidth)
    {
        int i = 0;
        int p = 0;
        double t = 0;
        int parent = 0;

        if( heapsize==0 )
        {
            return;
        }
        p = heapsize;
        while( p!=0 )
        {
            parent = (p-1)/2;
            if( heap[p,0]>heap[parent,0] )
            {
                for(i=0; i<=heapwidth-1; i++)
                {
                    t = heap[p,i];
                    heap[p,i] = heap[parent,i];
                    heap[parent,i] = t;
                }
                p = parent;
            }
            else
            {
                break;
            }
        }
    }
}
