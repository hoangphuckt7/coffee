import 'package:blue_bird_coffee_mobile/utils/enum.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutnine extends StatelessWidget {
  final String labelTxt;
  final TextEditingController controller;
  EFieldType? eFieldType = EFieldType.text;
  String? Function(String? value)? validator;
  FieldOutnine(
      {super.key,
      required this.labelTxt,
      required this.controller,
      this.eFieldType,
      this.validator});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: TextFormField(
        controller: controller,
        obscureText: eFieldType == EFieldType.password,
        decoration: InputDecoration(
          border: const UnderlineInputBorder(),
          labelText: labelTxt,
        ),
        validator: validator,
      ),
    );
  }
}
