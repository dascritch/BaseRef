<?php

namespace dascritch\tests\units;

require_once 'php-atoum/mageekguy.atoum.phar';

include_once '../baseref.php';

use \mageekguy\atoum;
use \dascritch;

class baseref extends atoum\test
{
	public $specifications = [];

	public function setUp() {
		// if i put here specification loading, they will be lost
	}

    public function testIsValid() {
        $BaseRef = new \dascritch\baseref();

		$this->specifications = json_decode(file_get_contents('specifications.json') ,true);

        foreach($this->specifications as $func_name => $tests) {
        	foreach($tests as $parameter => $expected) {
        		echo $func_name.'('.$parameter.') = ' ;
        		var_dump($expected);
        		$this->variable($BaseRef->$func_name($parameter))->isIdenticalTo($expected);
        	}
        }
    }
}