import unittest, io, json

specifications = json.load( open('specifications.json') )


#
class BaseRef():
	def encode(numeric) :
		return numeric
#

class BaseRefTests(unittest.TestCase):
    def test(self):
    	
        self.assertEqual( BaseRef.encode(3), 3)

if __name__ == '__main__':
    unittest.main()