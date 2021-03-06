﻿namespace DanhoLibrary.ORM
{
    public interface ICRUD
    {
        ICRUD CreateTable();
        ICRUD Insert();
        ICRUD Select(int primaryKey);
        ICRUD Update();
        ICRUD Delete();
    }
}
