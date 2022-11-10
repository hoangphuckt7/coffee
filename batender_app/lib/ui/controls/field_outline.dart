import 'package:bartender_app/utils/enum.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutnine extends StatelessWidget {
  final String labelText;
  final TextEditingController controller;
  final String? errorText;
  final EFieldType? eFieldType;
  final Function(String)? onChanged;
  const FieldOutnine({
    super.key,
    required this.labelText,
    required this.controller,
    required this.errorText,
    this.eFieldType = EFieldType.text,
    this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: TextFormField(
        controller: controller,
        obscureText: eFieldType == EFieldType.password,
        decoration: InputDecoration(
          border: const UnderlineInputBorder(),
          labelText: labelText,
          // labelStyle: TextStyle(fontWeight: FontWeight.bold),
          errorText: errorText,
        ),
        onChanged: onChanged,
      ),
    );
  }
}
