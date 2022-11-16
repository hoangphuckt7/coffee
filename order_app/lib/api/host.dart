// ignore_for_file: unused_field

class Host {
  static const String _localHost = 'https://localhost:7244';

  static const String _vmHost = 'https://10.0.2.2:7244';

  static const String _localIp = 'http://192.168.1.4:7244';

  static const String currentHost =
      String.fromEnvironment('ApiHost', defaultValue: _localIp);

  static const String currentHostApi = '$currentHost/api';
}
