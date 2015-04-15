﻿namespace Net
{
    using System;
    using UnityEngine;

    public class CEncrypt
    {
        public bool bEnc;
        public uint dec_mask;
        public static uint[,] des_skb = new uint[,] { { 
            0, 0x10, 0x20000000, 0x20000010, 0x10000, 0x10010, 0x20010000, 0x20010010, 0x800, 0x810, 0x20000800, 0x20000810, 0x10800, 0x10810, 0x20010800, 0x20010810, 
            0x20, 0x30, 0x20000020, 0x20000030, 0x10020, 0x10030, 0x20010020, 0x20010030, 0x820, 0x830, 0x20000820, 0x20000830, 0x10820, 0x10830, 0x20010820, 0x20010830, 
            0x80000, 0x80010, 0x20080000, 0x20080010, 0x90000, 0x90010, 0x20090000, 0x20090010, 0x80800, 0x80810, 0x20080800, 0x20080810, 0x90800, 0x90810, 0x20090800, 0x20090810, 
            0x80020, 0x80030, 0x20080020, 0x20080030, 0x90020, 0x90030, 0x20090020, 0x20090030, 0x80820, 0x80830, 0x20080820, 0x20080830, 0x90820, 0x90830, 0x20090820, 0x20090830
         }, { 
            0, 0x2000000, 0x2000, 0x2002000, 0x200000, 0x2200000, 0x202000, 0x2202000, 4, 0x2000004, 0x2004, 0x2002004, 0x200004, 0x2200004, 0x202004, 0x2202004, 
            0x400, 0x2000400, 0x2400, 0x2002400, 0x200400, 0x2200400, 0x202400, 0x2202400, 0x404, 0x2000404, 0x2404, 0x2002404, 0x200404, 0x2200404, 0x202404, 0x2202404, 
            0x10000000, 0x12000000, 0x10002000, 0x12002000, 0x10200000, 0x12200000, 0x10202000, 0x12202000, 0x10000004, 0x12000004, 0x10002004, 0x12002004, 0x10200004, 0x12200004, 0x10202004, 0x12202004, 
            0x10000400, 0x12000400, 0x10002400, 0x12002400, 0x10200400, 0x12200400, 0x10202400, 0x12202400, 0x10000404, 0x12000404, 0x10002404, 0x12002404, 0x10200404, 0x12200404, 0x10202404, 0x12202404
         }, { 
            0, 1, 0x40000, 0x40001, 0x1000000, 0x1000001, 0x1040000, 0x1040001, 2, 3, 0x40002, 0x40003, 0x1000002, 0x1000003, 0x1040002, 0x1040003, 
            0x200, 0x201, 0x40200, 0x40201, 0x1000200, 0x1000201, 0x1040200, 0x1040201, 0x202, 0x203, 0x40202, 0x40203, 0x1000202, 0x1000203, 0x1040202, 0x1040203, 
            0x8000000, 0x8000001, 0x8040000, 0x8040001, 0x9000000, 0x9000001, 0x9040000, 0x9040001, 0x8000002, 0x8000003, 0x8040002, 0x8040003, 0x9000002, 0x9000003, 0x9040002, 0x9040003, 
            0x8000200, 0x8000201, 0x8040200, 0x8040201, 0x9000200, 0x9000201, 0x9040200, 0x9040201, 0x8000202, 0x8000203, 0x8040202, 0x8040203, 0x9000202, 0x9000203, 0x9040202, 0x9040203
         }, { 
            0, 0x100000, 0x100, 0x100100, 8, 0x100008, 0x108, 0x100108, 0x1000, 0x101000, 0x1100, 0x101100, 0x1008, 0x101008, 0x1108, 0x101108, 
            0x4000000, 0x4100000, 0x4000100, 0x4100100, 0x4000008, 0x4100008, 0x4000108, 0x4100108, 0x4001000, 0x4101000, 0x4001100, 0x4101100, 0x4001008, 0x4101008, 0x4001108, 0x4101108, 
            0x20000, 0x120000, 0x20100, 0x120100, 0x20008, 0x120008, 0x20108, 0x120108, 0x21000, 0x121000, 0x21100, 0x121100, 0x21008, 0x121008, 0x21108, 0x121108, 
            0x4020000, 0x4120000, 0x4020100, 0x4120100, 0x4020008, 0x4120008, 0x4020108, 0x4120108, 0x4021000, 0x4121000, 0x4021100, 0x4121100, 0x4021008, 0x4121008, 0x4021108, 0x4121108
         }, { 
            0, 0x10000000, 0x10000, 0x10010000, 4, 0x10000004, 0x10004, 0x10010004, 0x20000000, 0x30000000, 0x20010000, 0x30010000, 0x20000004, 0x30000004, 0x20010004, 0x30010004, 
            0x100000, 0x10100000, 0x110000, 0x10110000, 0x100004, 0x10100004, 0x110004, 0x10110004, 0x20100000, 0x30100000, 0x20110000, 0x30110000, 0x20100004, 0x30100004, 0x20110004, 0x30110004, 
            0x1000, 0x10001000, 0x11000, 0x10011000, 0x1004, 0x10001004, 0x11004, 0x10011004, 0x20001000, 0x30001000, 0x20011000, 0x30011000, 0x20001004, 0x30001004, 0x20011004, 0x30011004, 
            0x101000, 0x10101000, 0x111000, 0x10111000, 0x101004, 0x10101004, 0x111004, 0x10111004, 0x20101000, 0x30101000, 0x20111000, 0x30111000, 0x20101004, 0x30101004, 0x20111004, 0x30111004
         }, { 
            0, 0x8000000, 8, 0x8000008, 0x400, 0x8000400, 0x408, 0x8000408, 0x20000, 0x8020000, 0x20008, 0x8020008, 0x20400, 0x8020400, 0x20408, 0x8020408, 
            1, 0x8000001, 9, 0x8000009, 0x401, 0x8000401, 0x409, 0x8000409, 0x20001, 0x8020001, 0x20009, 0x8020009, 0x20401, 0x8020401, 0x20409, 0x8020409, 
            0x2000000, 0xa000000, 0x2000008, 0xa000008, 0x2000400, 0xa000400, 0x2000408, 0xa000408, 0x2020000, 0xa020000, 0x2020008, 0xa020008, 0x2020400, 0xa020400, 0x2020408, 0xa020408, 
            0x2000001, 0xa000001, 0x2000009, 0xa000009, 0x2000401, 0xa000401, 0x2000409, 0xa000409, 0x2020001, 0xa020001, 0x2020009, 0xa020009, 0x2020401, 0xa020401, 0x2020409, 0xa020409
         }, { 
            0, 0x100, 0x80000, 0x80100, 0x1000000, 0x1000100, 0x1080000, 0x1080100, 0x10, 0x110, 0x80010, 0x80110, 0x1000010, 0x1000110, 0x1080010, 0x1080110, 
            0x200000, 0x200100, 0x280000, 0x280100, 0x1200000, 0x1200100, 0x1280000, 0x1280100, 0x200010, 0x200110, 0x280010, 0x280110, 0x1200010, 0x1200110, 0x1280010, 0x1280110, 
            0x200, 0x300, 0x80200, 0x80300, 0x1000200, 0x1000300, 0x1080200, 0x1080300, 0x210, 0x310, 0x80210, 0x80310, 0x1000210, 0x1000310, 0x1080210, 0x1080310, 
            0x200200, 0x200300, 0x280200, 0x280300, 0x1200200, 0x1200300, 0x1280200, 0x1280300, 0x200210, 0x200310, 0x280210, 0x280310, 0x1200210, 0x1200310, 0x1280210, 0x1280310
         }, { 
            0, 0x4000000, 0x40000, 0x4040000, 2, 0x4000002, 0x40002, 0x4040002, 0x2000, 0x4002000, 0x42000, 0x4042000, 0x2002, 0x4002002, 0x42002, 0x4042002, 
            0x20, 0x4000020, 0x40020, 0x4040020, 0x22, 0x4000022, 0x40022, 0x4040022, 0x2020, 0x4002020, 0x42020, 0x4042020, 0x2022, 0x4002022, 0x42022, 0x4042022, 
            0x800, 0x4000800, 0x40800, 0x4040800, 0x802, 0x4000802, 0x40802, 0x4040802, 0x2800, 0x4002800, 0x42800, 0x4042800, 0x2802, 0x4002802, 0x42802, 0x4042802, 
            0x820, 0x4000820, 0x40820, 0x4040820, 0x822, 0x4000822, 0x40822, 0x4040822, 0x2820, 0x4002820, 0x42820, 0x4042820, 0x2822, 0x4002822, 0x42822, 0x4042822
         } };
        public uint enc_mask;
        public const uint ITERATIONS = 0x10;
        public DES_key_schedule m_schedule = new DES_key_schedule();
        public static uint[,] MyDES_SPtrans = new uint[,] { { 
            0x2080800, 0x80000, 0x2000002, 0x2080802, 0x2000000, 0x80802, 0x80002, 0x2000002, 0x80802, 0x2080800, 0x2080000, 0x802, 0x2000802, 0x2000000, 0, 0x80002, 
            0x80000, 2, 0x2000800, 0x80800, 0, 0x2080802, 0x2000800, 0x80002, 0x2080802, 0x2080000, 0x802, 0x2000800, 2, 0x800, 0x80800, 0x2080002, 
            0x800, 0x2000802, 0x2080002, 0, 0x2080800, 0x80000, 0x802, 0x2000800, 0x2080002, 0x800, 0x80800, 0x2000002, 0x80802, 2, 0x2000002, 0x2080000, 
            0x2080802, 0x80800, 0x2080000, 0x2000802, 0x2000000, 0x802, 0x80002, 0, 0x80000, 0x2000000, 0x2000802, 0x2080800, 2, 0x2080002, 0x800, 0x80802
         }, { 
            0x8000000, 0x10000, 0x400, 0x8010420, 0x10000, 0x20, 0x8000020, 0x10400, 0x8000420, 0x8010020, 0x8010400, 0, 0x10400, 0x8000000, 0x10020, 0x420, 
            0x8010020, 0x8010400, 0x420, 0x10000, 0x8000400, 0x10420, 0, 0x8000020, 0x20, 0x8000420, 0x8010420, 0x10020, 0x8010000, 0x400, 0x420, 0x8010400, 
            0x10400, 0x8010020, 0x8000400, 0x420, 0x8010400, 0x8000420, 0x10020, 0x8010000, 0x10000, 0x20, 0x8000020, 0x8000400, 0x8000000, 0x10400, 0x8010420, 0, 
            0x10420, 0x8000000, 0x400, 0x10020, 0x8010020, 0x8000400, 0x10420, 0x8010000, 0x8000420, 0x400, 0, 0x8010420, 0x20, 0x10420, 0x8010000, 0x8000020
         }, { 
            0x40108010, 0, 0x108000, 0x40100000, 0x40000010, 0x8010, 0x40008000, 0x108000, 0x8000, 0x40100010, 0x10, 0x40008000, 0x100010, 0x40108000, 0x40100000, 0x10, 
            0x100000, 0x40008010, 0x40100010, 0x8000, 0x100010, 0x40108000, 0x40008000, 0x108010, 0x108010, 0x40000000, 0, 0x100010, 0x40008010, 0x108010, 0x40108000, 0x40000010, 
            0x40000000, 0x100000, 0x8010, 0x40108010, 0x40108010, 0x100010, 0x40000010, 0, 0x40000000, 0x8010, 0x100000, 0x40100010, 0x8000, 0x40000000, 0x108010, 0x40008010, 
            0x40108000, 0x8000, 0, 0x40000010, 0x10, 0x40108010, 0x108000, 0x40100000, 0x40100010, 0x100000, 0x8010, 0x40008000, 0x40008010, 0x10, 0x40100000, 0x108000
         }, { 
            0x4000, 0x200, 0x1000200, 0x1000004, 0x1004204, 0x4004, 0x4200, 0, 0x200, 0x1000004, 4, 0x1000200, 0x1000000, 0x1000204, 0x204, 0x1004000, 
            4, 0x1004200, 0x1004000, 0x204, 0x1000204, 0x4000, 0x4004, 0x1004204, 0, 0x1000200, 0x1000004, 0x4200, 0x1000204, 0x4204, 0x4200, 0, 
            0x204, 0x4000, 0x1004204, 0x1000000, 0x1004200, 4, 0x4004, 0x1004204, 0x1004004, 0x4204, 0x1004200, 4, 0x4204, 0x1004004, 0x200, 0x1000000, 
            0x4204, 0x1004000, 0x1004004, 0x204, 0x4000, 0x200, 0x1000000, 0x1004004, 0, 0x1000204, 0x1000200, 0x4200, 0x1000004, 0x1004200, 0x1004000, 0x4004
         }, { 
            0x80000040, 0x200040, 0, 0x80202000, 0x200040, 0x2000, 0x80002040, 0x200000, 0x2040, 0x80202040, 0x202000, 0x80000000, 0x80002000, 0x80000040, 0x80200000, 0x202040, 
            0x200000, 0x80002040, 0x80200040, 0, 0x2000, 0x40, 0x80202000, 0x80200040, 0x80202040, 0x80200000, 0x80000000, 0x2040, 0x40, 0x202000, 0x202040, 0x80002000, 
            0x80000040, 0x80200000, 0x202040, 0, 0x2040, 0x80000000, 0x80002000, 0x202040, 0x80202000, 0x200040, 0, 0x80002000, 0x80000000, 0x2000, 0x80200040, 0x200000, 
            0x200040, 0x80202040, 0x202000, 0x40, 0x80202040, 0x202000, 0x200000, 0x80002040, 0x2000, 0x80000040, 0x80002040, 0x80202000, 0x80200000, 0x2040, 0x40, 0x80200040
         }, { 
            0x4000001, 0x4040100, 0x100, 0x4000101, 0x40001, 0x4000000, 0x4000101, 0x40100, 0x4000100, 0x40000, 0x4040000, 1, 0x40100, 0, 0x4000000, 0x40101, 
            0x4040101, 0x101, 1, 0x4040001, 0, 0x40001, 0x4040100, 0x100, 0x101, 0x4040101, 0x40000, 0x4000001, 0, 0x4040100, 0x40100, 0x4040001, 
            0x4040001, 0x4000100, 0x40101, 0x4040000, 0x4040100, 0x100, 1, 0x40000, 0x101, 0x40001, 0x4040000, 0x4000101, 0x40001, 0x4000000, 0x4040101, 1, 
            0x40000, 0x4000100, 0x4000101, 0x40100, 0x40101, 0x4000001, 0x4000000, 0x4040101, 0x4000100, 0, 0x4040001, 0x101, 0x4000001, 0x40101, 0x100, 0x4040000
         }, { 
            0x401008, 0x10001000, 8, 0x10401008, 0, 0x10400000, 0x10001008, 0x400008, 0x10401000, 0x10000008, 0x10000000, 0x1008, 0x10000008, 0x401008, 0x400000, 0x10000000, 
            0x10400008, 0x401000, 0x1000, 8, 0x401000, 0x10001008, 0x10400000, 0x1000, 0x1008, 0, 0x400008, 0x10401000, 0x10001000, 0x10400008, 0x10401008, 0x400000, 
            0x10400008, 0x1008, 0x400000, 0x10000008, 0x401000, 0x10001000, 8, 0x10400000, 0x10001008, 0, 0x1000, 0x400008, 0, 0x10400008, 0x10401000, 0x1000, 
            0x10000000, 0x10401008, 0x401008, 0x400000, 0x10401008, 8, 0x10001000, 0x401008, 0x400008, 0x401000, 0x10400000, 0x10001008, 0x1008, 0x10000000, 0x10000008, 0x10401000
         }, { 
            0x20800080, 0x20820000, 0x20080, 0, 0x20020000, 0x800080, 0x20800000, 0x20820080, 0x80, 0x20000000, 0x820000, 0x20080, 0x820080, 0x20020080, 0x20000080, 0x20800000, 
            0x800000, 0x20000, 0x20000080, 0x20820080, 0x20000000, 0x800000, 0x20020080, 0x20800080, 0x20000, 0x820080, 0x800080, 0x20020000, 0x20820080, 0x20000080, 0, 0x820000, 
            0x800000, 0x20000, 0x20820000, 0x80, 0x20820000, 0x80, 0x800080, 0x20020000, 0x20080, 0x20000000, 0, 0x820000, 0x20800080, 0x20020080, 0x20020000, 0x800080, 
            0x20820080, 0x800000, 0x20800000, 0x20000080, 0x820000, 0x20080, 0x20020080, 0x20800000, 0x80, 0x20820000, 0x820080, 0, 0x20000000, 0x20800080, 0x20000, 0x820080
         } };

        public CEncrypt(bool enc)
        {
            this.bEnc = enc;
            this.init();
        }

        public static void DES_encrypt1(uint[] data, DES_key_schedule ks1, uint[,] sp, bool enc)
        {
            uint r = 0;
            uint l = 0;
            uint t = 0;
            uint u = 0;
            int s = 0;
            l = data[0];
            r = data[1];
            func_IP(ref l, ref r);
            l = func_ROTATE(ref l, 0x1d) & uint.MaxValue;
            r = func_ROTATE(ref r, 0x1d) & uint.MaxValue;
            if (enc)
            {
                for (s = 0; s < 0x20; s += 8)
                {
                    func_D_ENCRYPT(ref r, ref l, s, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref l, ref r, s + 2, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref r, ref l, s + 4, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref l, ref r, s + 6, ref u, ref t, ks1.arrKeys, sp);
                }
            }
            else
            {
                for (s = 30; s > 0; s -= 8)
                {
                    func_D_ENCRYPT(ref r, ref l, s, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref l, ref r, s - 2, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref r, ref l, s - 4, ref u, ref t, ks1.arrKeys, sp);
                    func_D_ENCRYPT(ref l, ref r, s - 6, ref u, ref t, ks1.arrKeys, sp);
                }
            }
            r = func_ROTATE(ref r, 3) & uint.MaxValue;
            l = func_ROTATE(ref l, 3) & uint.MaxValue;
            func_FP(ref l, ref r);
            data[0] = r;
            data[1] = l;
            r = l = t = u = 0;
        }

        public static void DES_set_key(DES_cblock key, DES_key_schedule schedule)
        {
            int[] numArray = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0 };
            uint l = 0;
            uint num2 = 0;
            uint t = 0;
            uint num4 = 0;
            uint a = 0;
            func_c2l_first(key.arrBlock, ref l);
            func_c2l_second(key.arrBlock, ref num2);
            func_PERM_OP(ref num2, ref l, ref t, 4, 0xf0f0f0f);
            func_HPERM_OP(ref l, ref t, -2, 0xcccc0000);
            func_HPERM_OP(ref num2, ref t, -2, 0xcccc0000);
            func_PERM_OP(ref num2, ref l, ref t, 1, 0x55555555);
            func_PERM_OP(ref l, ref num2, ref t, 8, 0xff00ff);
            func_PERM_OP(ref num2, ref l, ref t, 1, 0x55555555);
            num2 = (uint) (((((num2 & 0xff) << 0x10) | (num2 & 0xff00)) | ((num2 & 0xff0000) >> 0x10)) | ((l & -268435456) >> 4));
            l &= 0xfffffff;
            for (int i = 0; i < 0x10L; i++)
            {
                if (numArray[i] > 0)
                {
                    l = (l >> 2) | (l << 0x1a);
                    num2 = (num2 >> 2) | (num2 << 0x1a);
                }
                else
                {
                    l = (l >> 1) | (l << 0x1b);
                    num2 = (num2 >> 1) | (num2 << 0x1b);
                }
                l &= 0xfffffff;
                num2 &= 0xfffffff;
                num4 = ((des_skb[0, (int) ((IntPtr) (l & 0x3f))] | des_skb[1, (int) ((IntPtr) (((l >> 6) & 3) | ((l >> 7) & 60)))]) | des_skb[2, (int) ((IntPtr) (((l >> 13) & 15) | ((l >> 14) & 0x30)))]) | des_skb[3, (int) ((IntPtr) ((((l >> 20) & 1) | ((l >> 0x15) & 6)) | ((l >> 0x16) & 0x38)))];
                t = ((des_skb[4, (int) ((IntPtr) (num2 & 0x3f))] | des_skb[5, (int) ((IntPtr) (((num2 >> 7) & 3) | ((num2 >> 8) & 60)))]) | des_skb[6, (int) ((IntPtr) ((num2 >> 15) & 0x3f))]) | des_skb[7, (int) ((IntPtr) (((num2 >> 0x15) & 15) | ((num2 >> 0x16) & 0x30)))];
                a = ((t << 0x10) | (num4 & 0xffff)) & uint.MaxValue;
                schedule.arrKeys[2 * i] = func_ROTATE(ref a, 30) & uint.MaxValue;
                a = (num4 >> 0x10) | (t & 0xffff0000);
                schedule.arrKeys[(2 * i) + 1] = func_ROTATE(ref a, 0x1a) & uint.MaxValue;
            }
        }

        public void encdec_des(byte[] data, int index, int nLen, bool enc)
        {
            if (this.bEnc)
            {
                for (int i = 0; i <= (nLen - 8); i += 8)
                {
                    bool flag = false;
                    if (enc)
                    {
                        flag = LoginNetWork.IsNeedEncrypt(USAGE.eSend);
                        LoginNetWork.IncrementSendData();
                    }
                    else
                    {
                        flag = LoginNetWork.IsNeedEncrypt(USAGE.eRecv);
                        LoginNetWork.IncrementRecvData();
                    }
                    if (flag)
                    {
                        Debug.Log("有字节加密offset: " + (index + i));
                        uint[] numArray = new uint[] { this.ReadUInt32Encrypt(data, index + i), this.ReadUInt32Encrypt(data, (index + i) + 4) };
                        DES_encrypt1(numArray, this.m_schedule, MyDES_SPtrans, enc);
                        this.WriteUInt32Encrypt(data, index + i, numArray[0]);
                        this.WriteUInt32Encrypt(data, (index + i) + 4, numArray[1]);
                    }
                }
            }
        }

        private static void func_c2l_first(byte[] c, ref UInt32 l)
        {
            l = (UInt32)c[0];
            l |= (UInt32)c[1] << 8;
            l |= (UInt32)c[2] << 0x10;
            l |= (UInt32)c[3] << 0x18;
        }

        private static void func_c2l_second(byte[] c, ref uint l)
        {
            l = c[4];
            l |= (UInt32)c[5] << 8;
            l |= (UInt32)c[6] << 0x10;
            l |= (UInt32)c[7] << 0x18;
        }

        private static void func_D_ENCRYPT(ref uint LL, ref uint R, int S, ref uint u, ref uint t, uint[] s, uint[,] sp)
        {
            u = R ^ s[S];
            t = R ^ s[S + 1];
            t = func_ROTATE(ref t, 4);
            LL ^= ((((((sp[0, (u >> 2) & 0x3f] ^ sp[2, (u >> 10) & 0x3f]) ^ sp[4, (u >> 0x12) & 0x3f]) ^ sp[6, (u >> 0x1a) & 0x3f]) ^ sp[1, (t >> 2) & 0x3f]) ^ sp[3, (t >> 10) & 0x3f]) ^ sp[5, (t >> 0x12) & 0x3f]) ^ sp[7, (t >> 0x1a) & 0x3f];
        }

        private static void func_FP(ref uint l, ref uint r)
        {
            uint t = 0;
            func_PERM_OP(ref l, ref r, ref t, 1, 0x55555555);
            func_PERM_OP(ref r, ref l, ref t, 8, 0xff00ff);
            func_PERM_OP(ref l, ref r, ref t, 2, 0x33333333);
            func_PERM_OP(ref r, ref l, ref t, 0x10, 0xffff);
            func_PERM_OP(ref l, ref r, ref t, 4, 0xf0f0f0f);
        }

        private static void func_HPERM_OP(ref uint a, ref uint t, int n, uint m)
        {
            t = ((a << ((0x10 - n) & 0x1f)) ^ a) & m;
            a = (a ^ t) ^ (t >> ((0x10 - n) & 0x1f));
        }

        private static void func_IP(ref uint l, ref uint r)
        {
            uint t = 0;
            func_PERM_OP(ref r, ref l, ref t, 4, 0xf0f0f0f);
            func_PERM_OP(ref l, ref r, ref t, 0x10, 0xffff);
            func_PERM_OP(ref r, ref l, ref t, 2, 0x33333333);
            func_PERM_OP(ref l, ref r, ref t, 8, 0xff00ff);
            func_PERM_OP(ref r, ref l, ref t, 1, 0x55555555);
        }

        private static void func_PERM_OP(ref uint a, ref uint b, ref uint t, int n, uint m)
        {
            t = ((a >> (n & 0x1f)) ^ b) & m;
            b ^= t;
            a ^= t << (n & 0x1f);
        }

        private static uint func_ROTATE(ref uint a, int n)
        {
            return ((a >> (n & 0x1f)) | (a << ((0x20 - n) & 0x1f)));
        }

        public static uint func_ROTATE_LEFT(ref uint x, int n)
        {
            return ((x << (n & 0x1f)) | (x >> ((0x20 - n) & 0x1f)));
        }

        public void init()
        {
            this.enc_mask = this.dec_mask = uint.MaxValue;
            DES_cblock key = new DES_cblock();
            key.init();
            DES_set_key(key, this.m_schedule);
        }

        public uint ReadUInt32Encrypt(byte[] Buffer, int index)
        {
            return (uint) (((Buffer[index] + (Buffer[index + 1] << 8)) + (Buffer[index + 2] << 0x10)) + (Buffer[index + 3] << 0x18));
        }

        public void ResetKey(byte[] key, byte index)
        {
            this.enc_mask = this.dec_mask = uint.MaxValue;
            DES_cblock _cblock = new DES_cblock();
            _cblock.reset(key, index);
            DES_set_key(_cblock, this.m_schedule);
        }

        public void WriteUInt32Encrypt(byte[] Buffer, int index, uint b)
        {
            Buffer[index] = (byte) ((b << 0x18) >> 0x18);
            Buffer[index + 1] = (byte) ((b << 0x10) >> 0x18);
            Buffer[index + 2] = (byte) ((b << 8) >> 0x18);
            Buffer[index + 3] = (byte) (b >> 0x18);
        }

        public class DES_cblock
        {
            public byte[] arrBlock = new byte[8];

            public void init()
            {
                Debug.Log("Init Des key");
                byte[] buffer = new byte[] { 0x29, 0xfd, 1, 0x38, 0x34, 0x3e, 0xb0, 0x2a };
                for (int i = 0; i < 8; i++)
                {
                    this.arrBlock[i] = buffer[i];
                }
            }

            public void reset(byte[] key, byte index)
            {
                Debug.Log("Reset Des key");
                for (int i = 0; i < 8; i++)
                {
                    this.arrBlock[i] = key[i + index];
                }
            }
        }

        public class DES_key_schedule
        {
            public uint[] arrKeys = new uint[0x20];
        }
    }
}

