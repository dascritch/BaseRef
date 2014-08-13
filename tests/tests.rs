#![feature(phase)]
#[phase(plugin)]
extern crate regex_macros;
extern crate regex;


/*

extern crate regex;
use regex::Regex;
*/
/*
 #[path="../baseref.rs"]
mod baseref;
*/

#[allow(non_snake_case_functions)]
fn isValid(validate: &str) -> bool {
	// let glyphs = "0123456789ACDEHFJKMNPQRTUVWX";
	let rule = regex!(r"^[0123456789ACDEHFJKMNPQRTUVWX]*$");
	return rule.is_match(validate);
}

fn encode(b10: &str) -> &str {
	let glyphs = "0123456789ACDEHFJKMNPQRTUVWX";

    let base10: Option<int> = from_str(b10.as_slice().trim());

    match base10 {
        Some(number) => b10,
        None         => "0"
    }
    return b10
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
	assert_eq!(isValid("B"), false);
	assert_eq!(isValid("G"), false);
	assert_eq!(isValid("I"), false);
	assert_eq!(isValid("L"), false);
	assert_eq!(isValid("O"), false);
	assert_eq!(isValid("S"), false);
	assert_eq!(isValid("Y"), false);
	assert_eq!(isValid("Z"), false);
	assert_eq!(isValid("5FF90"), true);
	assert_eq!(isValid("4QZ0"), false);

	assert_eq!(encode("0"), "0");
	assert_eq!(encode("1"), "1");
}