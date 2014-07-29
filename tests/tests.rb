require "../baseref.rb"
require "test/unit"

class TestBaseRef < Test::Unit::TestCase

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
    end

end