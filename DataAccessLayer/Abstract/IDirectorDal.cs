﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDirectorDaL:IGenericDal<Director>
    {
        List<Director> Get10Director();
    }
}
