import re, math

class baseref():
    glyphs = '0123456789ACDEHFJKMNPQRTUVWX'
    base = len(glyphs)
    reg = re.compile(r'^['+glyphs+']*$')

    def isValid(self, chain) :
        if ( self.reg.match(chain) == None ) :
            return  False
        else :
            return True

    def encode(self, b10) :
        out = ''
        if isinstance(b10, str) :
            try:
                b10 = int(b10, 10)
            except ValueError:
                return False
        if (b10 < 0) or (b10 != round(b10)) :
            return False
        if (b10 >= self.base) :
            out = self.encode( math.floor( b10 / self.base ) )
            b10 = b10 % self.base
        out += self.glyphs[b10];
        return out

    def decode(self, based) :
        based = str.upper(based)
        if self.isValid(based) == False :
            return False
        numeric = 0;
        if (len(based) > 1) :
            numeric += self.decode( based[:-1] ) * self.base
            based = based[-1:]
        numeric += self.glyphs.index( based )
        return numeric;
