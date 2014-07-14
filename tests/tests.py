import unittest, io, json, collections, sys, os
sys.path.append( os.path.abspath('..' ) )
from baseref import baseref

# https://stackoverflow.com/questions/6921699/can-i-get-json-to-load-into-an-ordereddict-in-python
# https://docs.python.org/3.3/library/json.html#basic-usage function "load". Why didn't they put id="" on each function definition ????
specifications = json.load( open('specifications.json'),object_pairs_hook = collections.OrderedDict )

class BaseRefTests(unittest.TestCase):
    def test(self):
        BaseRef = baseref()
        for func_name , tests in sorted( specifications.items() ) :
            print(func_name)
            for parameter, expects in sorted( tests.items() ) :
                print(parameter, ' -> ', expects)
                self.assertEqual( getattr(BaseRef,func_name)(parameter), expects)

if __name__ == '__main__':
    unittest.main()