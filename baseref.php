<?php

namespace dascritch;

class baseref {
	private $glyphs = '0123456789ACDEFHJKMNPQRTUVWX';
	private $base = 0;

	public function __construct() {
		$this->base = strlen($this->glyphs);
	}

	public function isValid($test) {
		return preg_match( '/^['.$this->glyphs.']*$/', $test) === 1;
	}

	public function encode($b10) {
		if ( preg_match('/^\d+$/',$b10) !== 1) {
			return false;
		}
		$b10 = (float) $b10;
		if ( ($b10<0) || (($b10 - floor($b10)) != 0) ) {
			return false;
		}
		$b10 = (int) $b10;
		$out = '';
		if ($b10 >= $this->base) {
			$out .= $this->encode( floor($b10 / $this->base) );
			$b10 = $b10 % $this->base;
		}
		$out .= $this->glyphs[$b10];
		return $out;
	}

	public function decode($based) {
		$based = strtoupper($based);
		if (!$this->isValid($based)) {
			return false;
		}
		$b10 = 0;
		if (strlen($based)>1) {
			$b10 += $this->decode(substr($based,0,-1)) * $this->base;
			$based = substr($based,-1);
		}
		$b10 += (int) strpos($this->glyphs, $based);
		return $b10;
	}

}