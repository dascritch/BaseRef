require "test/unit"
require "json"
require "../baseref.rb"

class TestBaseRef < Test::Unit::TestCase

    '''
    def test_isValid()
        baseref = BaseRef.new()
        assert_equal(true , baseref.isValid(""))
        assert_equal(baseref.isValid("0"), true)
        assert_equal(baseref.isValid("A"), true)
        assert_equal(baseref.isValid("_"), false)
        assert_equal(baseref.isValid("B"), false)
        assert_equal(baseref.isValid("AX"), true)
        assert_equal(baseref.isValid("5FF90"), true)
        assert_equal(baseref.isValid("4QZ0"), false)
    end

    def test_encode()
        baseref = BaseRef.new()
        assert_equal("0" , baseref.encode("0"))
        assert_equal("1" , baseref.encode("1"))
        assert_equal("9" , baseref.encode("9"))
        assert_equal("A" , baseref.encode("10"))
        assert_equal("X" , baseref.encode("27"))
        assert_equal("10" , baseref.encode("28"))
        assert_equal("11" , baseref.encode("29"))
        assert_equal("1X" , baseref.encode("55"))
        assert_equal("XX" , baseref.encode("783"))
        assert_equal("100" , baseref.encode("784"))
        assert_equal(false , baseref.encode("-14"))
        assert_equal(false , baseref.encode("1.12"))
        assert_equal(false , baseref.encode("AA"))
    end

    def test_decode()
        baseref = BaseRef.new()
        assert_equal(0 , baseref.decode("0"))
        assert_equal(9 , baseref.decode("9"))
        assert_equal(10 , baseref.decode("A"))
        assert_equal(27 , baseref.decode("X"))
        assert_equal(28 , baseref.decode("10"))
        assert_equal(55 , baseref.decode("1X"))
        assert_equal(56 , baseref.decode("20"))
        assert_equal(783 , baseref.decode("XX"))
        assert_equal(784 , baseref.decode("100"))
        assert_equal(10 , baseref.decode("a"))
        assert_equal(783 , baseref.decode("xx"))
        assert_equal(false , baseref.decode("L"))
        assert_equal(false , baseref.decode("-AX") , "baseref.decode -AX ")
    end
    '''

    def test_fromSpecs()
        baseref = BaseRef.new()
        specs = JSON.load( File.open('specifications.json','r') )
        specs.each do |func_name,tests|
            puts(func_name)
            tests.each do |parameter,expects|
                assert_equal(
                    expects,
                    baseref.send(func_name,parameter),
                    "baseref."+func_name+"("+parameter.to_s+") -> "+expects.to_s
                    )
            end
        end
    end

end