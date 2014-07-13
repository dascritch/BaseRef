import unittest, io, re, json

class BaseRef():
    glyphs = '0123456789ACDEFGHJKMNPQRTUVWX'
    base = len(glyphs)
    reg = re.compile(r'^['+glyphs+']*$')

    def isValid(self, chain) :
        if ( self.reg.match(chain) == None ) :
            return  False
        else :
            return True

    def encode(self, b10) :
        out = ''
        try:
            b10 = int(b10, 10)
        except ValueError:
            return False
        if (b10 < 0) or (b10 != round(b10)) :
            return False
        if (b10 >= self.base) :
            out = self.encode( b10 / self.base )
            b10 = b10 % self.base
        out += self.glyphs[b10];
        return out

    def decode(self, based, multiplicande = 0) :
        if self.isValid(based) == False :
            # self.exception('not a valid coded-number');
            return False
        numeric = 0;
        if ( multiplicande == None ) :
             multiplicande = 1
        if (len(based) > 1) :
            numeric += self.decode( based[len(based)-1] , multiplicande + 1 ) * pow( self.base, multiplicande );
            based = based[:1];
        print('---',based)
        numeric += self.glyphs.index( based );
        return numeric;
#

# https://stackoverflow.com/questions/6921699/can-i-get-json-to-load-into-an-ordereddict-in-python
specifications = json.load( open('specifications.json') )

class BaseRefTests(unittest.TestCase):
    def test(self):
        baseref = BaseRef()
        for func_name , tests in sorted( specifications.items() ) :
            print(func_name)
            for parameter, expects in sorted( tests.items() ) :
                print(parameter, ' -> ', expects)
                self.assertEqual( getattr(baseref,func_name)(parameter), expects)

if __name__ == '__main__':
    unittest.main()