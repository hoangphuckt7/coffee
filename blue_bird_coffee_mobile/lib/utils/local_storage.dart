import 'dart:typed_data';

import 'package:shared_preferences/shared_preferences.dart';

class LocalStorage {
  static dynamic getItem(String key) async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.get(key);
  }

  static setItem(String key, dynamic data) async {
    final prefs = await SharedPreferences.getInstance();
    if (data is String) {
      prefs.setString(key, data);
    } else if (data is int) {
      prefs.setInt(key, data);
    } else if (data is double) {
      prefs.setDouble(key, data);
    } else if (data is bool) {
      prefs.setBool(key, data);
    } else if (data is List<String>) {
      prefs.setStringList(key, data);
    }
  }

  static dynamic removeItem(String key) async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.remove(key);
  }

  static removeAll() async {
    final prefs = await SharedPreferences.getInstance();
    var lstKey = prefs.getKeys();
    for (var key in lstKey) {
      prefs.remove(key);
    }
  }
}
