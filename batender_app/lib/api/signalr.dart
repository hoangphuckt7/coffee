import 'dart:async';
import 'dart:developer';

import 'package:bartender_app/api/host.dart';
import 'package:bartender_app/utils/const.dart';
import 'package:bartender_app/utils/local_storage.dart';
import 'package:signalr_core/signalr_core.dart';

class HubSignalR {
  static const String notificationHub = 'notificationHub';
}

class MethodSignalR {
  static const String newNotify = 'newNotify';
}

class SignalR {
  static const signalrUrl = Host.currentHost;
  Future<HubConnection?> newConnect(methodName) async {
    HubConnection? connection;
    try {
      var token = await LocalStorage.getItem(KeyLS.token);
      connection = HubConnectionBuilder()
          .withUrl(
              '$signalrUrl/$methodName',
              HttpConnectionOptions(
                accessTokenFactory: () async => token,
                //  logging: (level, message) => log(message),
              ))
          .withAutomaticReconnect()
          .build();
      log('signal state: ${connection.state}');
      if (connection.state != HubConnectionState.connected) {
        await connection.start();
      }
      log('signal state: ${connection.state}');
    } catch (e) {
      log('signalR err: ${e.toString()}');
    }
    return connection;
  }
}
