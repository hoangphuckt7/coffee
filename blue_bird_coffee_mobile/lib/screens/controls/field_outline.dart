import 'package:blue_bird_coffee_mobile/utils/enum.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutnine extends StatelessWidget {
  final String labelTxt;
  final TextEditingController controller;
  EFieldType? eFieldType = EFieldType.text;
  FieldOutnine(
      {super.key,
      required this.labelTxt,
      required this.controller,
      this.eFieldType});

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
        validator: (value) {
          if (value == null || value.isEmpty) {
            return "Lỗi";
          }
          return null;
        },
      ),
    );
  }
}
