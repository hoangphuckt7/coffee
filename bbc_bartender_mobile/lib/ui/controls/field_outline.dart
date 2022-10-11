import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutnine extends StatelessWidget {
  final String labelText;
  final TextEditingController controller;
  final String? errorText;
  EFieldType? eFieldType = EFieldType.text;
  final Function(String)? onChanged;
  FieldOutnine({
    super.key,
    required this.labelText,
    required this.controller,
    required this.errorText,
    this.eFieldType,
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
          errorText: errorText,
        ),
        onChanged: onChanged,
      ),
    );
  }
}
