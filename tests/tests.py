import unittest, io, re, json

specifications = json.load( open('specifications.json') )

class BaseRef():
    valids = '0123456789ACDEFGHJKMNPQRTUVWX'
    reg = re.compile(r'^['+valids+']*$')
    def isValid(self, chain) :
        if ( self.reg.match(chain) == None ) :
            return  False
        else :
            return True
    def encode(self, numeric) :
        return numeric
#

class BaseRefTests(unittest.TestCase):
    def test(self):
        baseref = BaseRef()
        for parameter, expects in specifications['isValid'].items() :
            self.assertEqual( baseref.isValid(parameter), expects)

if __name__ == '__main__':
    unittest.main()