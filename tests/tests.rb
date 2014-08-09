require "test/unit"
require "json"
require "../baseref.rb"

class TestBaseRef < Test::Unit::TestCase
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