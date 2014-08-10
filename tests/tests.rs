extern crate regex;
use regex::Regex;

/*

 #[path="../baseref.rs"]
mod baseref;
*/

#[allow(non_snake_case_functions)]
fn isValid(validate: &str) -> bool {
	let glyphs = "0123456789ACDEHFJKMNPQRTUVWX";
	let rule = Regex::new(r"^[0123456789ACDEHFJKMNPQRTUVWX]*$");

	return rule.is_match(validate);
}

#[test]
#[allow(non_snake_case_functions)]
fn this_tests_isValid() {
	assert!(isValid(""));
	assert!(isValid("0"));
	assert!(isValid("9"));
	assert!(isValid("A"));
	assert!(isValid("X"));
	assert_eq!(isValid("_"), false);
}

/*
#[test]
fn this_tests_code() {

	let baseref = BaseRef();
	baseref.isValid();
    //assert!(x == 2);
}

*/